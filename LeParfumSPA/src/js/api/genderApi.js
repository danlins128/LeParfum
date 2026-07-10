// HTTP GET 
export async function getGenders(){
    const response = await fetch("http://localhost:5276/api/Gender");

    if (!response.ok){
        throw new Error("Erro ao buscar gêneros");
    }

    return await response.json();
}