export async function injetarHTML(arquivo, idDestino, resposta) {
    await fetch(arquivo)
        .then(response => {
            if (!response.ok) throw new Error('Erro ao carregar ${arquivo}');
            return response.text();
        })
        .then(data => {
            const container = document.getElementById(idDestino);
            if (container) {
                container.innerHTML = data;
                if (resposta) resposta();
            }
        })
        .catch(error => console.error(error));
}