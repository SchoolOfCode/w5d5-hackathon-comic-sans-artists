const submitButton = document.querySelector("#submit-button");

const BACKEND_URL = "http://localhost:5000";

async function loadUsers(month) {
    const res = await fetch(`${BACKEND_URL}/users/april`);
    const data = await res.json();

    console.log(data);
    data.forEach(user => renderUser(user));
}

// async function sendUser(path, method, body = '') {
// 	const res = await fetch(`${BACKEND_URL}${path}`, {
// 		method,
// 		headers : {
// 			'content-type' : 'application/json',
// 		},
// 		body    : JSON.stringify(body),
// 	});
// 	const data = await res.json();
// 	return data;
// }

// async function addNewUser() {
//     event.preventDefault();
//     window.location.href="month-compare.html"

//     const user = {
// 		name    : event.target[0].value,
// 		day : event.target[1].value,
// 		month : event.target[2].value,
//     };
//     console.log(user);
    
//     await sendUser('/users', 'POST', user);
//     event.target.reset();
// }

// submitButton.addEventListener("submit", addNewUser);

const monthButtons = document.querySelectorAll(".month")

function renderUser(user) {
	const { id, name, day, monthBorn } = user;

	const p = document.createElement('p');
	p.innerHTML = `${name}: {day}th {monthBorn}.`;

	body.appendChild(user);
}


async function getByMonth(month) {
    window.event.preventDefault()

    loadUsers(month);
}

monthButtons.forEach(button => button.addEventListener("click", () => getByMonth(button.InnerText)));
