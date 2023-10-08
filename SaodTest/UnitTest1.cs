using SAOD_con;

namespace SaodTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SetAddTest()
    {
        MyHashSet<int> set = new MyHashSet<int>();
        set.Add(1);
        set.Add(3);
        set.Add(2);
        
        Assert.Pass(set == new MyHashSet<int>(new[] {1,3,2}));
    }

    [Test]
    public void SetAddSameTest()
    {
        MyHashSet<string> set = new MyHashSet<string>();
        set.Add("wasd");
        Assert.Pass(!set.Add("wasd"))));
    }
    
    [Test]
    public void SetNullAddTest()
    {
        MyHashSet<string> set = new MyHashSet<string>();
        Assert.Throws<ArgumentNullException>(set.Add(null));
    }
    
    [Test]
    public void SetNullContainsTest()
    {
        MyHashSet<string> set = new MyHashSet<string>();
        Assert.Throws<ArgumentNullException>(set.Contains(null));
    }

    [Test]
    public void SetContainsTest()
    {
        MyHashSet<string> set = new MyHashSet<string>();
        set.Add("bruhbruh");
        Assert.Pass(set.Contains("bruhbruh") && !set.Contains("asd"));
    }

    
    
    
}