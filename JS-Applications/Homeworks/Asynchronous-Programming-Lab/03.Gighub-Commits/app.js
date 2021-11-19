function loadCommits() {
    let username = document.getElementById('username').value;
    let repoName = document.getElementById('repo').value;
    let ul = document.getElementById('commits');
    ul.innerHTML = '';

    let url = `https://api.github.com/repos/${username}/${repoName}/commits`;

    fetch(url)
        .then((response) => {
            if (!response.ok) {
                throw response;
            }
            return response.json();
        })
        .then((repo) => {
            repo.forEach(commit => {
                let li = document.createElement('li');
                li.textContent = `${commit.commit.author.name}: ${commit.commit.message}`;
                ul.appendChild(li);
            });
        })
        .catch((err) => {
            let li = document.createElement('li');
            err.json().then(x => li.textContent = `Error: ${err.status} (${x.message})`)
            ul.appendChild(li);
        })
}