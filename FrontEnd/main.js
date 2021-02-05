const submitButton = document.querySelector("#submit-button");

const BACKEND_URL = "http://localhost:5001";

async function loadInitialUsers() {
    const res = await fetch(`${BACKEND_URL}/users`);
    const data = await res.json();
    data.forEach(renderUser);
}

