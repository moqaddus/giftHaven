let openPanelButton = document.getElementById("open-panel");
let closePanelButton = document.getElementById("close-panel");
let cartPanel = document.querySelector(".cart-panel");

openPanelButton.onclick = () => {
    cartPanel.classList.add("open");
    openPanelButton.classList.add("hide")
}

closePanelButton.onclick = () => {
    cartPanel.classList.remove("open");
    openPanelButton.classList.remove("hide");
}