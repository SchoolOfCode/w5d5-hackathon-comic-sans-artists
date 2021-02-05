const buddyList = document.querySelector(".birthday-buddies");
const monthBtns = document.querySelectorAll(".month");
const submitBtn = document.querySelector("#submit-button");

const backendURL = "http://localhost:5000";

async function getData(query) {
    const res = await fetch(`${backendURL}/users/${query}`);
    const data = await res.json();

    console.log(data[0])
}

getData("");

monthBtns.forEach(button => button.addEventListener("click", () => console.log(button.innerText)));

