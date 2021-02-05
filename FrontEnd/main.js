const buddyList = document.querySelector(".birthday-buddies");
const monthBtns = document.querySelectorAll(".month");
const birthdayForm = document.querySelector("#input-form");

const backendURL = "http://localhost:5000";

async function getData(query) {
    const res = await fetch(`${backendURL}/users/${query}`);
    const data = await res.json();

    data.forEach(item => displayUser(item));

    if (data.length === 0) {
        const li = document.createElement("li");
        li.innerHTML = `currently no users found for ${query}`;

        buddyList.appendChild(li);
    }
}

function displayUser(user) {
    const { id, fullName, day, month } = user;
    const dayStr = day.toString();
    let dayEnd = "";
    switch (dayStr[day.length -1]) {
        case 1:
            dayEnd = "st";
            break;
        case 2:
            dayEnd = "nd";
            break;
        case 3:
            dayEnd = "rd";
            break;
        default:
            dayEnd = "th"
    }
    
    const li = document.createElement("li");
    li.innerHTML = `${fullName} <span class="birthday">${day}${dayEnd} of ${month}</span>`

    buddyList.appendChild(li);
}

monthBtns.forEach(button => button.addEventListener("click", () => {
    buddyList.innerHTML = "";

    getData(button.innerText);
}));


async function submitUser(event) {
    event.preventDefault();

    const newUser = {
        fullName : event.target[0].value,
        day : event.target[1].value,
        month : event.target[2].value,
    }
    
    await postUser("/users", "POST", newUser);
}

async function postUser(path, method, body) {
    const res = await fetch(`${backendURL}${path}`, {
		method,
		headers : {
			'content-type' : 'application/json',
		},
		body    : JSON.stringify(body),
	});
	// const data = await res.json();
}

birthdayForm.addEventListener("submit", submitUser)
//initial load
getData("");