export function configurarBotoesSetas() {
    const btnPrevCard = document.querySelector('#btn-prev')
    const btnNextCard = document.querySelector('#btn-next')
    const scrollCarrossel = document.querySelector('#container-carrossel')
    const larguraCard = 900;

    btnPrevCard.addEventListener('click', () => {
        scrollCarrossel.scrollLeft -= larguraCard;
    });

    btnNextCard.addEventListener('click', () => {
        scrollCarrossel.scrollLeft += larguraCard;
    });
}

export function configurarMenuMobile() {
    const btnMenu = document.querySelector('#btn-menu-mobile')
    const menu = document.querySelector('#menu-flutuante')
    const iconeHamburguer = document.querySelector('#icone-hamburguer');
    const iconeX = document.querySelector('#icone-x');

    if (btnMenu && menu && iconeHamburguer && iconeX) {
        btnMenu.addEventListener('click', () => {
            menu.classList.toggle('translate-x-full');
            iconeHamburguer.classList.toggle('hidden');
            iconeX.classList.toggle('hidden');
        });
    }
}

export function configurarScrollHorizontal() {
    const scrollCarrossel = document.querySelector('#container-carrossel')
    scrollCarrossel.addEventListener('wheel', function (evento) {
        if (evento.deltaY != 0) {
            evento.preventDefault();
            scrollCarrossel.scrollLeft += evento.deltaY * 1.5;
        }
    });
}

export async function painelResumo(objeto, painel) {
    try {

        const quantidade = await objeto.length;

        const numeroPainel = document.getElementById(painel);

        numeroPainel.innerHTML = '';

        numeroPainel.textContent = quantidade;

    } catch (error) {
        console.error("Não foi possível pegar o tamanho dos arrays", error);
    }
}

export function mostrarNotificacao(mensagem, tipo = 'sucesso') {
    const container = document.getElementById("toast-container");
    if (!container) {
        return;
    }

    const toast = document.createElement('div');

    toast.className = `pointer-events-auto flex items-center p-4 rounded-lg shadow-lg text-white font-medium 
        transition-all duration-300 transform translate-x-20 opacity-0 min-w-[250px]
        ${tipo === 'sucesso' ? 'bg-emerald-600' : 'bg-rose-600'}`;

    const icone = tipo === 'sucesso' ? '✅' : '❌';

    toast.innerHTML = `<span class="mr-2">${icone}</span> <span>${mensagem}</span>`;

    container.appendChild(toast);

    setTimeout(() => {
        toast.classList.remove('translate-x-20', 'opacity-0');
        toast.classList.add('translate-x-0', 'opacity-100');
    }, 10);

    setTimeout(() => {
        toast.classList.remove('translate-x-0', 'opacity-100');
        toast.classList.add('translate-x-20', 'opacity-0');


        setTimeout(() => toast.remove(), 300);
    }, 3000);

}