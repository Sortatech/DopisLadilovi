// wwwroot/passphrase.js
window.passphraseConfig = {
    correctPassphrase: "Aut viam inveniam aut faciam",
    challenge: "Es in malo loco, quomodo ad locum bonum pervenies?"
};

window.validatePassphrase = (input) => {
    return input === window.passphraseConfig.correctPassphrase;
};

window.getChallenge = () => {
    return window.passphraseConfig.challenge;
};

window.toggleOverlay = (selector) => {
    const linkElem = document.querySelector(selector);
    if (linkElem) {
        linkElem.classList.toggle('clicked');
    }
};