import { getBrands } from "./api/brandApi.js";
import { getCategories } from "./api/categoryApi.js";
import { getGenders } from "./api/genderApi.js";
import { preencherSelect } from "./components/preencherSelect.js";
import { injetarHTML } from "./components/injetarHtml.js";
import { renderizarTabelaProdutos } from "./components/renderTable.js";
import { painelResumo, mostrarNotificacao } from "./ui/ui.js";
import {
    getAllProducts,
    createProduct,
    deleteProduct
} from "./api/productApi.js";


let brandsGlobal = [];
let categoriesGlobal = [];
let gendersGlobal = [];
let productsGlobal = [];

// Forma rápida de buscar os dados, todos ao mesmo tempo
try {
    const [brands, categories, genders, products] = await Promise.all([
        getBrands(),
        getCategories(),
        getGenders(),
        getAllProducts()
    ]);

    brandsGlobal = brands;
    categoriesGlobal = categories;
    gendersGlobal = genders;
    productsGlobal = products;

    preencherSelect("filterBrands", brands);
    preencherSelect("filterCategories", categories);
    preencherSelect("filterGenders", genders);
    painelResumo(productsGlobal, 'total-produtos');
    painelResumo(categoriesGlobal, "total-categorias");
    painelResumo(brandsGlobal, "total-marcas");
    renderizarTabelaProdutos(productsGlobal);   

} catch (error) {
    console.error("Erro ao buscar dados da API.", error);
}

// Injeção de header e sidebar

await injetarHTML('/src/html/dashboard/header.html', 'header', null);
await injetarHTML('/src/html/dashboard/sidebar.html', 'sidebar', null);

const btnNewProduct = document.getElementById("btnNewProduct");
const btnDeleteProduct = document.getElementById("btn-delete");
const bodyTable = document.getElementById("productTableBody");

if (bodyTable) {
    bodyTable.addEventListener('click', async (event) => {
        const deleteBtn = event.target.closest('.btn-delete');

        if (!deleteBtn) return;

        const productId = deleteBtn.getAttribute('data-id');
        const confirmDelete = confirm("Tem certeza que deseja excluir esse produto?");

        if (!confirmDelete) return;

        try {
            await deleteProduct(productId);
            const update = await getAllProducts();
            await renderizarTabelaProdutos(update);
            painelResumo(update, 'total-produtos');
            mostrarNotificacao("Produto excluído com sucesso", "sucesso");

        } catch (error) {
            console.error("Erro ao tentar excluir:", error);
            mostrarNotificacao("Não foi possível excluir o produto.", "erro");
        }
    })
}


// Abrir modal de novo produto
btnNewProduct.addEventListener("click", async () => {
    await injetarHTML('/src/html/dashboard/newProduct.html', 'newProduct', () => {
        const modal = document.getElementById("modalNewProduct");
        const form = document.getElementById("newProductForm");
        const btnCloseModal = document.getElementById('btnCloseModal');
        if (modal) {
            modal.classList.remove("hidden");
            modal.classList.add("flex");
        }

        if (form) {
            form.addEventListener("submit", async (event) => {
                event.preventDefault(); // Impede a página de carregar.

                const productData = {
                    name: document.getElementById("productName").value,
                    brandId: document.getElementById("select-brand").value,
                    categoryId: document.getElementById("select-category").value,
                    description: document.getElementById("description").value,
                    price: parseFloat(document.getElementById("price").value),
                    genderId: document.getElementById("select-gender").value
                };

                try {

                    const result = await createProduct(productData);
                    const update = await getAllProducts();
                    painelResumo(update, 'total-produtos');
                    renderizarTabelaProdutos(update);
                    mostrarNotificacao("Produto salvo com sucesso!", 'sucesso');
                    form.reset();
                    modal.classList.remove("flex");
                    modal.classList.add("hidden");

                } catch (error) {
                    console.error(error);
                    mostrarNotificacao("Houve um erro ao salvar o produto. Verifique o console.", 'erro');
                }
            });
        }

        if (btnCloseModal) {
            btnCloseModal.addEventListener('click', () => {
                modal.classList.remove("flex");
                modal.classList.add("hidden");
            });
        }

        preencherSelect("select-brand", brandsGlobal);
        preencherSelect("select-category", categoriesGlobal);
        preencherSelect("select-gender", gendersGlobal);
    });
});





/* TO.DO 
 ----- Alimentar tabela de resumo ----- 
2º Colocar os destaques if true
*/
