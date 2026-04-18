// Известна стоимость 1 кг конфет, печенья и яблок. Найти стоимость всей покупки,
// если купили x кг конфет, у кг печенья и z кг яблок.

Console.WriteLine("Цены:\n1кг конфет - 14,30р \n1кг печенья - 10,50р \n1кг яблок - 7,85р\n");
Console.Write("Сколько килограммов конфет вы хотите купить? ");
double x = double.Parse(Console.ReadLine());
Console.Write("Сколько килограммов печенья вы хотите купить? ");
double y = double.Parse(Console.ReadLine());
Console.Write("Сколько килограммов яблок вы хотите купить? ");
double z = double.Parse(Console.ReadLine());
double sweets = 14.3;
double cookies = 10.5;
double apples = 7.85;
Console.WriteLine($"Общая стоимость покупки: {(x*sweets+y*cookies+z*apples):F2}р");
