// HTTP POST 
export async function createProduct(productData) {
    const response = await fetch("http://localhost:5276/api/Product", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(productData) // Transforma o objeto JS em texto JSON para envio
    });

    const text = await response.text()

    if (!response.ok) {

        throw new Error(text || "Erro ao criar produto no servidor");
    }


    if (!text || text.trim() === "") {
        return { success: true };
    }

    try {
        return JSON.parse(text);
    } catch (e) {
        return { success: true, message: text };
    }
}

// HTTP GET
export async function getAllProducts() {
    const response = await fetch("http://localhost:5276/api/Product");

    if (response.ok) {
        return await response.json();
    }
    else {
        throw new Error("Erro ao buscar os produtos na API.")
    }
}

//HTTP GET BY ID
export async function getProductById(id) {
    const response = await fetch(`http://localhost:5276/api/Product/${id}`,);

    if (response.ok) return await response.json();

    else throw new Error("Erro ao buscar o produto na API");
}

// HTTP DELETE
export async function deleteProduct(id){
    const response = await fetch(`http://localhost:5276/api/Product/${id}`, {
        method: "DELETE"
    });

    if (!response.ok){
        const errorText = await response.text();
        throw new Error(errorText || "Produto não encontrado.");
    }
    return true;
}

// HTTP PUT
export async function updateProduct(id, productData) {
    const response = await fetch(`http://localhost:5276/api/Product/${id}`,{
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(productData)
    });

    const text = await response.text()

    if (!response.ok) {

        throw new Error(text || "Erro ao criar produto no servidor");
    }


    if (!text || text.trim() === "") {
        return { success: true };
    }

    try {
        return JSON.parse(text);
    } catch (e) {
        return { success: true, message: text };
    }
}