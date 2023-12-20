using System;
using System.Collections.Generic;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void Test_ConstructorShouldWork()
    {
        HeroRepository repo = new HeroRepository();

        Assert.AreEqual(0, repo.Heroes.Count);
        Assert.True(repo.Heroes != null);
    }

    [Test]
    public void Test_CreateShouldWork()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = new Hero("Batman", 100);

        Assert.AreEqual("Batman", hero.Name);
        Assert.AreEqual(100 , hero.Level);

        string expectedResult = "Successfully added hero Batman with level 100";

        Assert.AreEqual(expectedResult, repo.Create(hero));
        Assert.AreEqual(1, repo.Heroes.Count);
    }

    [Test]
    public void Test_CreateShouldThrowWhenHeroIsNull()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            repo.Create(hero);
        });
    }

    [Test]
    public void Test_CreateShouldThrowHeroExists()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = new Hero("Batman", 100);

        repo.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            repo.Create(hero);
        });
    }

    [Test]
    public void Test_RemoveShouldWork()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = new Hero("Batman", 100);

        repo.Create(hero);

        Assert.AreEqual(true, repo.Remove("Batman"));
    }

    [Test]
    public void Test_RemoveShouldThrowWhenNameIsNull()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = new Hero("Batman", 100);

        repo.Create(hero);

        Assert.Throws<ArgumentNullException>(() =>
        {
            Assert.AreEqual(true, repo.Remove(""));
        });

        Assert.Throws<ArgumentNullException>(() =>
        {
            Assert.AreEqual(true, repo.Remove(null));
        });
    }

    [Test]
    public void Test_GetHeroWithHighestLevelShouldWork()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = new Hero("Batman", 100);
        Hero hero2 = new Hero("Spidy", 50);
        Hero hero3 = new Hero("Joker", 500);

        repo.Create(hero);
        repo.Create(hero2);
        repo.Create(hero3);
        
        Assert.AreEqual(hero3, repo.GetHeroWithHighestLevel());
    }

    [Test]
    public void Test_GetHeroShouldWork()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = new Hero("Batman", 100);
        Hero hero2 = new Hero("Spidy", 50);
        Hero hero3 = new Hero("Joker", 500);

        repo.Create(hero);
        repo.Create(hero2);
        repo.Create(hero3);

        Assert.AreEqual(hero2, repo.GetHero("Spidy"));
    }

    [Test]
    public void Test_HeroesColleciton()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = new Hero("Batman", 100);
        Hero hero2 = new Hero("Spidy", 50);
        Hero hero3 = new Hero("Joker", 500);

        repo.Create(hero);
        repo.Create(hero2);
        repo.Create(hero3);

        List<Hero> heroes = new List<Hero>();
        heroes.Add(hero);
        heroes.Add(hero2);
        heroes.Add(hero3);

        Assert.AreEqual(heroes, repo.Heroes);
    }
}