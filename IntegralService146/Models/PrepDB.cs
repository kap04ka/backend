using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System.Linq;

namespace IntegralService146.Models
{
    public static class PrepDB
    {
        public static void PrepQuestion(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<QuestionContext>());
            }

        }
        public static void SeedData(QuestionContext context)
        {
            System.Console.WriteLine("Appling Migrations...");

            context.Database.Migrate();

            if (!context.Questions.Any())
            {
                System.Console.WriteLine("Already data - seeding...");
                context.Questions.AddRange(
                        new Question() { QuestionText = "Какие объекты исследует вычислительная математика? ", Answer1 = "только непрерывные объекты", Answer2 = "только дискретные объекты", Answer3 = "как непрерывные, так и дискретные объекты", Answer4 = "Никакие из предложенных", RightAnswer = 3 },
                        new Question() { QuestionText = "Какой из методов численной оптимизации позволяет гарантированно найти глобальный оптимум ", Answer1 = "градиентный метод ", Answer2 = "cимплексный метод ", Answer3 = "метод случайного поиска ", Answer4 = "метод перебора", RightAnswer = 4 },
                        new Question() { QuestionText = "Какой из численных методов решения систем линейных алгебраических уравнений требует наименьшее число операций ", Answer1 = "метод прогонки ", Answer2 = "метод Гаусса-Зейделя ", Answer3 = "метод обратной матрицы ", Answer4 = "метод Крамера ", RightAnswer = 1 },
                        new Question() { QuestionText = "В каком из указанных ниже случаев увеличение числа узлов всегда ведёт к улучшению сходимости аппроксимирующей функции ", Answer1 = "при использовании многочленов Лагранжа ", Answer2 = "при использовании многочленов Ньютона ", Answer3 = "при использовании рядов Фурье ", Answer4 = "во всех указанных случаях ", RightAnswer = 3 },
                        new Question() { QuestionText = "Какой из указанных ниже методов решения обыкновенного дифференциального уравнения является одношаговым методом первого порядка точности ", Answer1 = "метод Эйлера ", Answer2 = "метод Адамса ", Answer3 = "метод Рунге-Кутты ", Answer4 = "метод Эйлера с пересчетом ", RightAnswer = 1 },
                        new Question() { QuestionText = "Какой из указанных ниже методов является методом поиска минимума функционала в виде определенного интеграла ", Answer1 = "метод Ньютона ", Answer2 = "метод Ритца ", Answer3 = "метод Лагранжа ", Answer4 = "метод Коши ", RightAnswer = 2 },
                        new Question() { QuestionText = "Какой из указанных методов численной оптимизации многомерной функции требует вычисления так называемой «отраженной вершины» ", Answer1 = "градиентный метод ", Answer2 = "метод случайного поиска ", Answer3 = "метод перебора ", Answer4 = "симплексный метод ", RightAnswer = 4 },
                        new Question() { QuestionText = "В каком из указных ниже методов коэффициенты аппроксимирующей функции определяются с использованием критерия аппроксимации ", Answer1 = "метод интерполяции ", Answer2 = "метод Лагранжа ", Answer3 = "метод Ньютона ", Answer4 = "метод Фурье ", RightAnswer = 1 },
                        new Question() { QuestionText = "Какое количество членов аппроксимирующей функции рекомендуется использовать при применении полиномов Лагранжа и Ньютона ", Answer1 = "меньше 5 ", Answer2 = "больше 5 и меньше 10 ", Answer3 = "больше 10 и меньше 20 ", Answer4 = "больше 20 ", RightAnswer = 1 },
                        new Question() { QuestionText = "В каких из указанных ниже аппроксимирующих полиномов в качестве базисных используются ортогональные многочлены ", Answer1 = "полиномы Лагранжа ", Answer2 = "полиномы Ньютона ", Answer3 = "полиномы Лежандра ", Answer4 = "полиномы Чебышева ", RightAnswer = 4 },
                        new Question() { QuestionText = "В каком из указных ниже методов решения систем линейных уравнений требуется неравенство нулю диагонального элемента ", Answer1 = "метод Крамера ", Answer2 = "метод прогонки ", Answer3 = "метод обратной матрицы ", Answer4 = "метод Гаусса ", RightAnswer = 2 },
                        new Question() { QuestionText = "Какой из указанных ниже методов решения систем линейных уравнений является итерационным ", Answer1 = "метод Крамера", Answer2 = "метод обратной матрицы ", Answer3 = "метод Гаусса - Зейделя ", Answer4 = "метод прогонки ", RightAnswer = 3 },
                        new Question() { QuestionText = "Какие из указанных ниже номиналов используются при экономизации по Ланцошу ", Answer1 = "полинома Чебышева ", Answer2 = "полинома Лагранжа ", Answer3 = "полинома Ньютона ", Answer4 = "полинома Фурье ", RightAnswer = 2 },
                        new Question() { QuestionText = "В каком из указных ниже методов численного интегрирования используется нелинейная аппроксимация дискретных значений подынтегральной функции ", Answer1 = "метод прямоугольнико ", Answer2 = "метод трапеции ", Answer3 = "метод Симпсона ", Answer4 = "метод Монте - Карло ", RightAnswer = 3 },
                        new Question() { QuestionText = "Как зависит погрешность численного дифференцирования от изменения шага дискретизации h ", Answer1 = "увеличивается с уменьшением h", Answer2 = "уменьшается с уменьшением h ", Answer3 = "не меняется при изменении h ", Answer4 = "уменьшается с уменьшением h, а затем возрастает ", RightAnswer = 4 }
                    );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data - not seeding");
            }

        }
    }
}