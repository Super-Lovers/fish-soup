using Zenject;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class TestFriendlyEntityBindings : ZenjectUnitTestFixture
{
    private NPCEntity npc = null;

    [SetUp]
    public void InstallBindings()
    {
        TestInstaller.InstallFromResource("TestInstaller", Container);

        GameObject npc = Container.InstantiatePrefabResource("Prefabs/Entities/NPCEntity");
        this.npc = npc.GetComponent<NPCEntity>();
    }

    [Test]
    public void GetNPCProperties()
    {
        GameObject npc = Container.InstantiatePrefabResource("Prefabs/Entities/NPCEntity");
        this.npc = npc.GetComponent<NPCEntity>();
        Assert.NotNull(this.npc.GetProperties());
    }

    [Test]
    public void GetNPCHealthController()
    {
        Assert.NotNull(this.npc.GetProperties().GetHealthController());
    }
}

[TestFixture]
public class TestFriendlyEntityBehaviour : ZenjectUnitTestFixture
{
    private NPCEntity npc;

    [SetUp]
    public void InstallBindings()
    {
        TestInstaller.InstallFromResource("TestInstaller", Container);

        GameObject npc = Container.InstantiatePrefabResource("Prefabs/Entities/NPCEntity");
        this.npc = npc.GetComponent<NPCEntity>();
    }

    [Test]
    public void GetNPCLabel()
    {
        Assert.AreEqual("Default NPC", this.npc.GetProperties().GetLabel());
    }

    [Test]
    public void SetNPCLabel()
    {
        this.npc.GetProperties().SetLabel("Cherni Kotaraci");
        string newNPCLabel = this.npc.GetProperties().GetLabel();

        Assert.AreEqual("Cherni Kotaraci", newNPCLabel);
    }
}

[TestFixture]
public class TestFoeEntityBindings : ZenjectUnitTestFixture
{
    [SetUp]
    public void InstallBindings()
    {
        TestInstaller.InstallFromResource("TestInstaller", Container);
    }

    [Test]
    public void BindPlayer()
    {
        PlayerController player = Container.Resolve<PlayerController>();
        Assert.NotNull(player);
    }

    [Test]
    public void CreateFoeFactory()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();
        Assert.NotNull(factory);
    }

    [Test]
    public void CreateFoe()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();
        Assert.IsNotNull(shark);
    }

    [Test]
    public void GetFoeProperties()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();
        Assert.IsNotNull(shark.GetProperties());
    }

    [Test]
    public void GetFoeStateMachine()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();
        Assert.IsNotNull(shark.GetStateMachine());
    }

    [Test]
    public void GetFoeKillableController()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();
        Assert.IsNotNull(shark.GetKillableController());
    }

    [Test]
    public void GetFoeDeathController()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();
        Assert.IsNotNull(shark.GetKillableController().GetDeathController());
    }

    [Test]
    public void GetFoeHealthController()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();
        Assert.IsNotNull(shark.GetProperties().GetHealthController());
    }

    [Test]
    public void GetFoeCombatController()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();
        Assert.IsNotNull(shark.GetProperties().GetCombatController());
    }
}

[TestFixture]
public class TestFoeEntityPropertiesBehaviour : ZenjectUnitTestFixture
{
    [SetUp]
    public void InstallBindings()
    {
        TestInstaller.InstallFromResource("TestInstaller", Container);
    }

    [Test]
    public void GetFoeLabel()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();
        Assert.AreEqual("Shark", shark.GetProperties().GetLabel());
    }

    [Test]
    public void SetFoeLabel()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();

        shark.GetProperties().SetLabel("Shark");
        string newSharkLabel = shark.GetProperties().GetLabel();
        Assert.AreEqual("Shark", newSharkLabel);
    }
}

[TestFixture]
public class TestFoeEntityCombatBehaviour : ZenjectUnitTestFixture
{
    [SetUp]
    public void InstallBindings()
    {
        TestInstaller.InstallFromResource("TestInstaller", Container);
    }

    [Test]
    public void GetAbilitiesController()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();
        Assert.IsNotNull(shark.GetProperties().GetCombatController().GetAbilitiesController());
    }

    [Test]
    public void GetFoeDamage()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();

        int sharkDamage = shark.GetProperties().GetCombatController().GetDamage();
        Assert.AreEqual(1, sharkDamage);
    }

    [Test]
    public void SetFoeDamage()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();
        shark.GetProperties().GetCombatController().SetDamage(1);

        int sharkDamage = shark.GetProperties().GetCombatController().GetDamage();
        Assert.AreEqual(1, sharkDamage);
    }

    [Test]
    public void DamageAnotherEntity()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();
        SharkEntity enemyShark = factory.Create();

        int oldSharkHealth = enemyShark.GetProperties().GetHealthController().GetHealth();
        shark.GetProperties().GetCombatController().DamageEntity(enemyShark);
        int newSharkHealth = enemyShark.GetProperties().GetHealthController().GetHealth();

        Assert.AreEqual(oldSharkHealth - shark.GetProperties().GetCombatController().GetDamage(), newSharkHealth);
    }
}

[TestFixture]
public class TestFoeEntityStateMachineBehaviour : ZenjectUnitTestFixture
{
    [SetUp]
    public void InstallBindings()
    {
        TestInstaller.InstallFromResource("TestInstaller", Container);
    }

    [Test]
    public void GetFoeState()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();
        State sharkState = shark.GetStateMachine().GetState();
        Assert.AreEqual(State.Idle, sharkState);
    }

    [Test]
    public void SetFoeState()
    {
        SharkEntity.Factory factory = Container.Resolve<SharkEntity.Factory>();

        SharkEntity shark = factory.Create();
        shark.GetStateMachine().SetState(State.Battle);

        Assert.AreEqual(State.Battle, shark.GetStateMachine().GetState());
    }
}