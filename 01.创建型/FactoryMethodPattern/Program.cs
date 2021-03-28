using Autofac;
using System;

namespace FactoryMethodPattern
{
    static class Program
    {
        static void Main(string[] args)
        {
            // 这里显示 new 对象的地方同样可以通过 配置+反射 和 依赖注入 的方式去做，可参考 抽象工厂模式
            IWorkFactory factory = new UndergraduteFactory();
            var studentLeifeng = factory.CreateWorker();
            studentLeifeng.BuyRice();
            var studentLeifeng1 = factory.CreateWorker();
            studentLeifeng1.Sweep();

            // 依赖注入
            var builder = new ContainerBuilder();
            builder.RegisterType<VolunteerFactory>().As<IWorkFactory>();
            var container = builder.Build();
            var leifengFactory = container.Resolve<IWorkFactory>();
            var volunteer = leifengFactory.CreateWorker();
            volunteer.Wash();

            Console.ReadLine();
        }
    }
}
