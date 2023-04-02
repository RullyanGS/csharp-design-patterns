using System;

namespace RefactoringGuru.DesignPatterns.FactoryMethod.Conceptual
{
  //Classe Creator declara o método de fábrica que deve retornar um objeto de uma classe Produto.
  //As subclasses de Creator geralmente fornecem a implementação desse método.
  abstract class Creator
  {
    // Note que a classe Creator também pode fornecer alguma implementação padrão do método de fábrica.
    public abstract IProduct FactoryMethod();

    // Também observe que, apesar de seu nome, a responsabilidade principal do Creator não é criar produtos.
    // Geralmente, ele contém alguma lógica de negócios central que depende de objetos Produto, retornados
    // pelo método de fábrica. As subclasses podem alterar indiretamente essa lógica de negócios
    // sobrescrevendo o método de fábrica e retornando um tipo diferente de produto.
    public string SomeOperation()
    {
      // Chame o método de fábrica para criar um objeto Produto.
      var product = FactoryMethod();
      // Agora, use o produto.
      var result = "Creator: The same creator's code has just worked with "
          + product.Operation();

      return result;
    }
  }

  // Os Concrete Creators sobrescrevem o método de fábrica para alterar o tipo do produto resultante.
  class ConcreteCreator1 : Creator
  {
    // Observe que a assinatura do método ainda usa o tipo abstrato do produto, embora o produto
    // concreto seja realmente retornado pelo método. Dessa forma, o Creator pode permanecer
    // independente das classes de produto concretas.
    public override IProduct FactoryMethod()
    {
      return new ConcreteProduct1();
    }
  }

  class ConcreteCreator2 : Creator
  {
    public override IProduct FactoryMethod()
    {
      return new ConcreteProduct2();
    }
  }

  // A interface Produto declara as operações que todos os produtos concretos devem implementar.
  public interface IProduct
  {
    string Operation();
  }

  // Os produtos concretos fornecem várias implementações da interface Produto.
  class ConcreteProduct1 : IProduct
  {
    public string Operation()
    {
      return "{Result of ConcreteProduct1}";
    }
  }

  class ConcreteProduct2 : IProduct
  {
    public string Operation()
    {
      return "{Result of ConcreteProduct2}";
    }
  }

  class Client
  {
    public void Main()
    {
      Console.WriteLine("App: Launched with the ConcreteCreator1.");
      ClientCode(new ConcreteCreator1());

      Console.WriteLine("");

      Console.WriteLine("App: Launched with the ConcreteCreator2.");
      ClientCode(new ConcreteCreator2());
    }

    // O código do cliente trabalha com uma instância de um Concrete Creator,
    // embora através de sua interface base. Enquanto o cliente continuar
    // trabalhando com o Creator por meio da interface base, você pode passar
    // a ele qualquer subclasse do Creator.
    public void ClientCode(Creator creator)
    {
      // ...
      Console.WriteLine("Client: I'm not aware of the creator's class," +
          "but it still works.\n" + creator.SomeOperation());
      // ...
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      new Client().Main();
    }
  }
}