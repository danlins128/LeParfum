export function injetarCards(arquivo, idDestino, quantidade, resposta) {
    fetch(arquivo)
        .then(response => response.text())
        .then(cardHTML => {
            const container = document.getElementById(idDestino);
            if (!container) return;

            container.innerHTML = '';

            for (let i = 0; i < quantidade; i++) {
                container.insertAdjacentHTML('beforeend', cardHTML);
            }
            if (resposta) resposta();
        })
        .catch(error => console.error(error));
}