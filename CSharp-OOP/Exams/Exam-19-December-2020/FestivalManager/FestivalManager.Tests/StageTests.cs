// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        [Test]
        public void Given_PerformerConstructor_When_IsCalled_Then_WorkCorreclty()
        {
            Performer performer = new Performer("Georgi", "Ivanow", 35);


            string expectedFullName = "Georgi Ivanow";
            int expectedAge = 35;

            string actualFirstName = performer.FullName;
            int actualAge = performer.Age;

            Assert.AreEqual(expectedFullName, actualFirstName);
            Assert.AreEqual(expectedAge, actualAge);
            Assert.IsTrue(performer.SongList != null);
        }

        [Test]
        public void Given_PerformenToString_When_IsCalled_Then_ReturnFullName()
        {
            Performer performer = new Performer("Georgi", "Ivanow", 35);

            string expectedFullName = "Georgi Ivanow";

            string actualFirstName = performer.ToString();

            Assert.AreEqual(expectedFullName, actualFirstName);
        }

        [Test]
        public void Given_StageConstructor_When_IsCalled_Then_WorkCorrectly()
        {
            Stage stage = new Stage();

            Assert.IsTrue(stage.Performers != null);
        }

        [Test]
        public void Given_AddPerformer_When_IsCalled_Then_AddPerformerCorrectly()
        {
            Performer performer = new Performer("Georgi", "Ivanow", 35);
            Stage stage = new Stage();

            stage.AddPerformer(performer);

            int expectedResult = 1;
            int actualResult = stage.Performers.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Given_AddPerformer_When_IsCalled_Then_ThrowExeptionIfAgeAreLessThan18()
        {
            Performer performer = new Performer("Georgi", "Ivanow", 15);
            Stage stage = new Stage();

            Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
        }

        [Test]
        public void Given_AddPerformer_When_IsCalled_Then_ThrowExeptionIfArgumenIsNull()
        {
            Performer performer = null;
            Stage stage = new Stage();

            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer));
        }

        [Test]
        public void Given_AddSong_When_IsCalled_Then_ThrowExceptioIfDurationIsLessThanOne()
        {
            Song song = new Song("In the end", new TimeSpan(0, 00, 59));
            Stage stage = new Stage();

            Assert.Throws<ArgumentException>(() => stage.AddSong(song));
        }

        [Test]
        public void Given_AddSong_When_IsCalled_Then_ThrowExceptioIfArgumenIsNull()
        {
            Song song = null;
            Stage stage = new Stage();

            Assert.Throws<ArgumentNullException>(() => stage.AddSong(song));
        }

        [Test]
        public void Given_AddSongToPerformer_When_IsCalled_Then_WorkCorrectly()
        {
            Performer performer = new Performer("Georgi", "Ivanow", 25);
            Song song = new Song("In the end", new TimeSpan(0, 01, 59));
            Stage stage = new Stage();
            stage.AddPerformer(performer);
            stage.AddSong(song);

            string expectedResult = $"{song.ToString()} will be performed by {performer.FullName}";
            string actualResult = stage.AddSongToPerformer(song.Name, performer.FullName);

            int expectedPerfomerSongsCount = 1;
            int actualPErfomerSongsCount = performer.SongList.Count;

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedPerfomerSongsCount, actualPErfomerSongsCount);
        }

        [Test]
        public void Given_AddSongToPerformer_When_IsCalled_Then_ThrowExceptionIfSongNotExist()
        {
            Performer performer = new Performer("Georgi", "Ivanow", 25);
            Song song = new Song("In the end", new TimeSpan(0, 01, 59));
            Stage stage = new Stage();
            stage.AddPerformer(performer);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song.Name,performer.FullName));
        }

        [Test]
        public void Given_AddSongToPerformer_When_IsCalled_Then_ThrowExceptionIfPerformerNotExist()
        {
            Performer performer = new Performer("Georgi", "Ivanow", 25);
            Song song = new Song("In the end", new TimeSpan(0, 01, 59));
            Stage stage = new Stage();
            stage.AddSong(song);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song.Name,performer.FullName));
        }

        [Test]
        public void Given_Play_When_IsCalled_Then_WorkCorrectly()
        {
            Performer performer = new Performer("Georgi", "Ivanow", 25);
            Song song = new Song("In the end", new TimeSpan(0, 01, 59));
            Stage stage = new Stage();
            stage.AddSong(song);
            stage.AddPerformer(performer);
            stage.AddSongToPerformer(song.Name, performer.FullName);

            string expectedResult = $"1 performers played 1 songs";
            string actualResult = stage.Play();

            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}