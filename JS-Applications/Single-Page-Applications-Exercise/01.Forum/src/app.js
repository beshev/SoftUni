import topic from './topic.js';
import comments from './comments.js';

const main = document.getElementById('main');
const newTopicSection = document.getElementById('newTopic');
const commentsSection = document.getElementById('comments');
const answerDiv = document.getElementById('answer-comment');
const home = document.querySelector('nav a');
home.addEventListener('click',() => topic.showTopics());

topic.setTopic(main, newTopicSection);
topic.showTopics();

comments.setComment(main, commentsSection, answerDiv);

document.getElementById('views').remove();