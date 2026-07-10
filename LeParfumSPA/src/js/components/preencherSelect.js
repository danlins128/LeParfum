export function preencherSelect(selectId, dataList) {
    const selectElement = document.getElementById(selectId);

    if (!selectElement) {
        console.error(`Elemento select com id "${selectId}" não encontrado.`);
        return;
    }

    // Limpa as opções existentes
    // selectElement.innerHTML = '';


    // Preenche o select com os dados fornecidos
    dataList.forEach(item => {
        // 1 Cria o elemento <option>
        const option = document.createElement('option');

        // 2 Define o value com o GUID do banco (item.id)
        option.value = item.id;

        // 3 Define o texto visível com o nome do item (item.name)
        option.textContent = item.name;

        // 4 Adiciona a opção ao select
        selectElement.appendChild(option);
    });
}