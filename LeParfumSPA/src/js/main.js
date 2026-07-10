import { injetarHTML } from "./components/injetarHtml.js";
import { injetarCards } from "./components/injetarCards.js";

import {
    configurarMenuMobile,
    configurarBotoesSetas,
    configurarScrollHorizontal
} from "./ui/ui.js";


injetarHTML('/src/html/components/navbar.html', 'navbar-placeholder', function () {
    configurarMenuMobile();
})
injetarCards('/src/html/components/card.html', 'carrossel-cards', 9, function () {
    configurarScrollHorizontal();
    configurarBotoesSetas();
})


