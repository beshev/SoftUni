async function loadRepos() {
	let username = document.getElementById('username').value;
	let url = `https://api.github.com/users/${username}/repos`;

	let ul = document.getElementById('repos');
	ul.innerHTML = '';

	// (Then - Catch)  way
	// fetch(url)
	// 	.then((response) => {
	// 		if (!response.ok) { throw response.status }
	// 		return response.json();
	// 	})
	// 	.then((repos) => {
	// 		repos.forEach(repo => {
	// 			let li = document.createElement('li');
	// 			let a = document.createElement('a');
	// 			a.textContent = repo.full_name;
	// 			a.href = repo.html_url;
	// 			li.appendChild(a);
	// 			ul.appendChild(li);
	// 		});
	// 	})
	// 	.catch((err) => {
	// 		let li = document.createElement('li');
	// 		li.textContent = `Error occurred: ${err}`;
	// 		ul.appendChild(li);
	// 	});

	
	// (Async - Await) way
	let response = await fetch(url);
	if (response.ok) {
		let repos = await response.json();
		repos.forEach(repo => {
			let li = document.createElement('li');
			let a = document.createElement('a');
			a.textContent = repo.full_name;
			a.href = repo.html_url;
			li.appendChild(a);
			ul.appendChild(li);
		});
	} else {
		let li = document.createElement('li');
		li.textContent = `Error occurred: ${response.status}`;
		ul.appendChild(li);
	}
}