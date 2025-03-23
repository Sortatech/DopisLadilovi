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

window.toggleOverlay = () => {
    const linkElem = document.querySelector('.hebkost');
    if (linkElem) {
        linkElem.classList.toggle('clicked');
    }
};