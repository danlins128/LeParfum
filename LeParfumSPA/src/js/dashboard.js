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
    deleteProduct,
    updateProduct,
    getProductById
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

await injetarHTML('/LeParfumSPA/src/html/dashboard/header.html', 'header', null);
await injetarHTML('/LeParfumSPA/src/html/dashboard/sidebar.html', 'sidebar', null);

const btnNewProduct = document.getElementById("btnNewProduct");
const btnDeleteProduct = document.getElementById("btn-delete");
const btnViewProduct = document.getElementById("btn-view");
const btnEditProduct = document.getElementById("btn-edit");
const bodyTable = document.getElementById("productTableBody");

if (bodyTable) {
    bodyTable.addEventListener('click', async (event) => {
        const deleteBtn = event.target.closest('.btn-delete');
        const viewBtn = event.target.closest('.btn-view');
        const editBtn = event.target.closest('.btn-edit');

        if (deleteBtn) {
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
                return;
            } return;
        }



        if (editBtn) {
            // Abrir modal de editar produto
            const productId = editBtn.getAttribute('data-id');
            const productObj = productsGlobal.find(p => String(p.id) === String(productId));            

            await injetarHTML('/LeParfumSPA/src/html/dashboard/editProduct.html', 'modalProduct', () => {
                const modal = document.getElementById('modalEditProduct');
                const form = document.getElementById('editProductForm');
                const btnCloseModal = document.getElementById('btnCloseModal');

                preencherSelect("select-brand", brandsGlobal);
                preencherSelect("select-category", categoriesGlobal);
                preencherSelect("select-gender", gendersGlobal);

                document.getElementById("productName").value = productObj.name;
                document.getElementById("select-brand").value = productObj.brandId;
                document.getElementById("select-category").value = productObj.categoryId;
                document.getElementById("description").value = productObj.description;
                document.getElementById("price").value = productObj.price;
                document.getElementById("select-gender").value = productObj.genderId;
                document.getElementById('isHighLighted').checked = productObj.isHighLighted;

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
                            genderId: document.getElementById("select-gender").value,
                            isHighLighted: document.getElementById('isHighLighted').checked
                        }

                        try {
                            await updateProduct(productId, productData);

                            const updated = await getAllProducts();

                            productsGlobal = updated;

                            await renderizarTabelaProdutos(updated);

                            modal.classList.remove("flex");
                            modal.classList.add("hidden");

                            mostrarNotificacao("Produto alterado com sucesso!", "sucesso");
                        }
                        catch (erro) {
                            console.log("Erro ao atualizar o produto", erro);
                            mostrarNotificacao("Erro ao atualizar o produto!", "erro");
                        }
                    });
                }
                if (btnCloseModal) {
                    btnCloseModal.addEventListener('click', () => {
                        modal.classList.remove("flex");
                        modal.classList.add("hidden");
                    });
                }
            });
            return;
        }

    });
}


// Abrir modal de novo produto
btnNewProduct.addEventListener("click", async () => {
    await injetarHTML('/LeParfumSPA/src/html/dashboard/newProduct.html', 'modalProduct', () => {
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
                    genderId: document.getElementById("select-gender").value,
                    isHighLighted: document.getElementById('isHighLighted').checked
                };

                try {

                    const result = await createProduct(productData);
                    const update = await getAllProducts();
                    painelResumo(update, 'total-produtos');
                    renderizarTabelaProdutos(update);
                    mostrarNotificacao("Produto salvo com sucesso!", 'sucesso');
                    productsGlobal = update;
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
