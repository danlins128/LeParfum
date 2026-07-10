export async function getBrands(){
    const response = await fetch("http://localhost:5276/api/Brand");

    if (!response.ok){
        throw new Error("Erro ao buscar marcas");
    }

    return await response.json();
}