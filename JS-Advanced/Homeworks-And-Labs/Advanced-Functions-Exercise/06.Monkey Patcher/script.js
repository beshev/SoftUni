function solution(command) {
    
    if (command == 'upvote') {
        this.upvotes++;
    } else if (command == 'downvote') {
        this.downvotes++;
    } else if (command == 'score') {
        let reportedScore = Math.ceil(Math.max(this.upvotes,this.downvotes) * 0.25);
        let totalVotes = this.upvotes + this.downvotes;

        let reportUpVotes = totalVotes > 50 ? reportedScore : 0;
        let reportDownVotes = totalVotes > 50 ? reportedScore : 0;
        reportUpVotes += this.upvotes;
        reportDownVotes += this.downvotes;

        let balance = reportUpVotes - reportDownVotes;
        
       return [reportUpVotes, reportDownVotes, balance,calcRating(this.upvotes, this.downvotes)];
    }

    function calcRating (u, d) {
        if (u + d < 10) return 'new'
        if (u > (u + d) * 0.66) return 'hot'
        if (u - d >= 0 && (u > 100 || d > 100)) return 'controversial'
        if (u - d < 0) return 'unpopular'

        return 'new'
    }
}


let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 4,
    downvotes: 1,
};
// solution.call(post, 'upvote');
// solution.call(post, 'downvote');
let score = solution.call(post, 'score'); // [127, 127, 0, 'controversial']
console.log(score);
for (let i = 0; i < 50; i++) {
    solution.call(post, 'downvote');        // (executed 50 times)
}
score = solution.call(post, 'score'); 
console.log(score);   
