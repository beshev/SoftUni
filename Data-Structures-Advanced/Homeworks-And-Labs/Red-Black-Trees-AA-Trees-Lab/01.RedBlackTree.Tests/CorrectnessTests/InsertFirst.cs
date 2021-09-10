using _01.RedBlackTree;
using NUnit.Framework;

[TestFixture]
class InsertFirst
{
    [Test]
    public void Insert_SingleElement_ShouldIncreaseCount()
    {
        RedBlackTree<int> rbt = new RedBlackTree<int>();
        rbt.Insert(5);

        Assert.AreEqual(1, rbt.Count());
    }


    [Test]
    public void IMustDeleteThisTest()
    {
        RedBlackTree<int> rbt = new RedBlackTree<int>();
        //rbt.Insert(5);
        rbt.Insert(3);
        rbt.Insert(4);
    }
}
