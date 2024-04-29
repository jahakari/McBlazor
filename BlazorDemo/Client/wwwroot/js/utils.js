
function setLocalStorageItem(key, item) {
    localStorage.setItem(key, JSON.stringify(item));
}

function getLocalStorageItem(key) {
    return JSON.parse(localStorage.getItem(key));
}