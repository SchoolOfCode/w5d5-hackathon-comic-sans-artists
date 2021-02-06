const buddyList = document.querySelector(".birthday-buddies");
const monthBtns = document.querySelectorAll(".month");
const birthdayForm = document.querySelector("#input-form");

const backendURL = "http://localhost:5000";

async function getData(query) {
    const res = await fetch(`${backendURL}/users/${query}`);
    const data = await res.json(); //gets data

    data.forEach(item => displayUser(item)); //adds each user to ul one by one

    if (data.length === 0) { //for if database returns nothing
        const li = document.createElement("li");
        li.innerHTML = `currently no users found for ${query}`;

        buddyList.appendChild(li);
    }
}

function displayUser(user) {
    const { id, fullName, day, month } = user; //object destructuring for easy access
    const dayStr = day.toString(); //turn day into string to allow switch to access only the last character

    //sets so 2nd, 3rd etc read correctly 
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
    
    const li = document.createElement("li"); //make li
    li.innerHTML = `${fullName} <span class="birthday">${day}${dayEnd} of ${month}</span>`; //populate with user data

    buddyList.appendChild(li); //display on ul
}

monthBtns.forEach(button => button.addEventListener("click", () => {
    buddyList.innerHTML = ""; //remove existing list

    getData(button.innerText); //call get data with the month (is equal to inner text)
}));


async function submitUser(event) {
    event.preventDefault(); //stop page reload

    const newUser = { //turn form data into user object to pass to API
        fullName : event.target[0].value,
        day : event.target[1].value,
        month : event.target[2].value,
    }
    
    await postUser("/users", "POST", newUser); //Send post request to /users
}

async function postUser(path, method, body) {
    const res = await fetch(`${backendURL}${path}`, {
		method,
		headers : {
			'content-type' : 'application/json',
		},
		body    : JSON.stringify(body), //turns body object into json
	});
}

birthdayForm.addEventListener("submit", submitUser);

getData(""); //initial load