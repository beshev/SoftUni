function solution() {
    class Post{
        constructor(title, content){
            this.title = title;
            this.content = content;
        }

        toString(){
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }
    
    class SocialMediaPost extends Post{
        constructor(title, content, likes, dislikes){
            super(title, content);
            this.likes = Number(likes);
            this.dislikes = Number(dislikes);
            this._comments = [];
        }

        get comments(){
            return this._comments;
        }

        addComment(comment){
            this._comments.push(comment);
        }

        toString(){
            let result = super.toString();
            result += `\nRating: ${this.likes - this.dislikes}\n`
            if (this.comments.length > 0) {
                result += 'Comments:\n'
                this.comments.forEach(comment => {
                    result += ` * ${comment}\n`;
                });
            }
            return result.trimEnd('\n');
        }
    }

    class BlogPost extends Post{
        constructor(title, content, views){
            super(title, content);
            this.views = Number(views);
        }

        view(){
            this.views++;
            return this;
        }

        toString(){
            return `${super.toString()}\nViews: ${this.views}`;
        }
    }

    return {Post,SocialMediaPost,BlogPost};
}