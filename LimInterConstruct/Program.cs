namespace LimInterConstruct
{
    class Program
    {
        public T CloneObject<T>(T original) where T : IClonable<T>
        {
            return original.Clone();
        }
        static void Main(string[] args)
        {
            var productRepository = new ProductRepository();
            var userRepository = new UserRepository();

            productRepository.Add(new Product(1, "Ноутбук", 1000));
            productRepository.Add(new Product(2, "Телефон", 700));
            productRepository.Add(new Product(3, "Стилус", 500));

            userRepository.Add(new User(1, "Иванов", "Улица Пушкина"));
            userRepository.Add(new User(2, "Петров", "Улица Амурская"));
            userRepository.Add(new User(3, "Кузнецов", "Улица Белогорская"));

            Console.WriteLine("Продукты:");
            foreach (var product in productRepository.GetAll())
            {
                Console.WriteLine($"ID: {product.Id}, Название: {product.Name}, Цена: {product.Price}");
            }

            Console.WriteLine("\nКлиенты:");
            foreach (var user in userRepository.GetAll())
            {
                Console.WriteLine($"ID: {user.Id}, Имя: {user.Name}, Адрес: {user.Address}");
            }

            int productIdToFind = 2;
            var foundProduct = productRepository.FindById(productIdToFind);
            if (foundProduct != null)
            {
                Console.WriteLine($"\nПродукт с ID {productIdToFind}: {foundProduct.Name}");
            }
            else
            {
                Console.WriteLine($"\nПродукт с ID {productIdToFind} не найден.");
            }

            int userIdToFind = 3;
            var foundUser = userRepository.FindById(userIdToFind);
            if (foundUser != null)
            {
                Console.WriteLine($"\nКлиент с ID {userIdToFind}: {foundUser.Name}");
            }
            else
            {
                Console.WriteLine($"\nКлиент с ID {userIdToFind} не найден.");
            }
            Console.WriteLine("-------------------------------------");

            var program = new Program();

            Point point1 = new Point(1, 2);
            Point point2 = program.CloneObject(point1);

            Rectangle rect1 = new Rectangle(new Point(1, 2), new Point(3, 4));
            Rectangle rect2 = program.CloneObject(rect1);

            Console.WriteLine($"Скопированая точка: ({point2.X}, {point2.Y})");
            Console.WriteLine($"Скопированый прямоугольник: левая верхняя - ({rect2.UpperLeft.X}, { rect2.UpperLeft.Y}), нижняя правая - ( {rect2.LowerRight.X}, {rect2.LowerRight.Y})");

            Console.WriteLine("-------------------------------------");

            ComplexNumber complex1 = new ComplexNumber(3, 4);
            ComplexNumber complex2 = new ComplexNumber(1, 2);

            RationalNumber rational1 = new RationalNumber(3, 5);
            RationalNumber rational2 = new RationalNumber(1, 3);

            IComparer<ComplexNumber> complexComparer = new ComplexNumber();
            IComparer<RationalNumber> rationalComparer = new RationalNumber();

            int complexComparison = complexComparer.Compare(complex1, complex2);
            int rationalComparison = rationalComparer.Compare(rational1, rational2);

            Console.WriteLine("Сравнение комплексных чисел: " + complexComparison);
            Console.WriteLine("Сравнение рациональных чисел: " + rationalComparison);
        }
    }
}