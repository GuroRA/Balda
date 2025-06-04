using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

/// <summary>
///  Предоставляет установщик для регистрации зависимостей валидатора слов в контейнере Castle Windsor.
/// </summary>
public class ValidatorsInstaller : IWindsorInstaller
{
    private readonly string _dictionaryFilePath;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ValidatorsInstaller"/>.
    /// </summary>
    public ValidatorsInstaller(string dictionaryFilePath)
    {
        _dictionaryFilePath = dictionaryFilePath;
    }

    /// <summary>
    /// Регистрирует реализацию в контейнере Windsor.
    /// </summary>
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(
            Castle.MicroKernel.Registration.Component.For<Balda.IWordValidator>()
                .ImplementedBy<DictionaryWordValidator>()
                .LifestyleSingleton()
                .DependsOn(Dependency.OnValue("dictionaryFilePath", _dictionaryFilePath))
        );
    }
}