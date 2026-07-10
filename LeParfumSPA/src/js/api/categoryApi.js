export async function getCategories() {
    const response = await fetch("http://localhost:5276/api/Category");

    if (!response.ok) {
        throw new Error("Erro ao buscar categorias");
    }

    return await response.json();
}