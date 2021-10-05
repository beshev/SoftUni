class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length == 0) {
            return `${this.title} has 0 likes`;
        }

        if (this._likes.length == 1) {
            return `${this._likes[0]} likes this story!`;
        }

        return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`;
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw Error(`You can't like the same story twice!`);
        }

        if (this.creator === username) {
            throw Error(`You can't like your own story!`);
        }
        this._likes.push(username);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (!this._likes.includes(username)) {
            throw Error("You can't dislike this story!");
        }

        this._likes = this._likes.filter(x => x !== username);
        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        let comment = this._comments.find(x => x.id == id);
        if (!comment) {
            comment = {
                id: this._comments.length + 1,
                username,
                content,
                replies: [],
            }
            this._comments.push(comment);
            return `${username} commented on ${this.title}`;
        } else {
            let replay = {
                id: comment.replies.length + 1,
                username,
                content,
            }
            comment.replies.push(replay);
            return `You replied successfully`;
        }
    }

    toString(sortingType) {
        let result = [];

        result.push(`Title: ${this.title}`);
        result.push(`Creator: ${this.creator}`);
        result.push(`Likes: ${this._likes.length}`);
        result.push(`Comments:`);

        if (sortingType === 'asc') {
            this._comments.sort((a, b) => a.id - b.id);
            this._comments.forEach(el => {
                el.replies.sort((a, b) => a.id - b.id);
            });
        } else if (sortingType === 'desc') {
            this._comments.sort((a, b) => b.id - a.id);
            this._comments.forEach(el => {
                el.replies.sort((a, b) => b.id - a.id);
            });
        } else if (sortingType === 'username') {
            this._comments.sort((a, b) => a.username.localeCompare(b.username));
            this._comments.forEach(el => {
                el.replies.sort((a, b) => a.username.localeCompare(b.username));
            });
        }

        for (const comment of this._comments) {
            result.push(`-- ${comment.id}. ${comment.username}: ${comment.content}`);
            for (const replay of comment.replies) {
                result
                    .push(`--- ${comment.id}.${replay.id}. ${replay.username}: ${replay.content}`);
            }
        }

        return result.join('\n');
    }
}