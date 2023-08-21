
namespace DungeonOfSparta
{
    // 게임 시작 화면
    // 게임 시작시 간단한 소개, 마을에서 할 수 있는 행동

    // 상태 보기
    // 캐릭터의 정보를 표시
    // 7개의 속성 레벨,이름,직업,공격력,방어력,체력,돈

    // 인벤토리
    // 보유 중인 아이템을 전부 보여준다.
    // 장착중인 아이템 앞에는 [E] 표시가 붙는다

    // 장착 관리
    // 아이템 목록 앞에 숫자가 표시
    // 장착 중이지 않다면 장착하고 [E] 표시 추가
    // 장착 중이라면 [E] 표시 없애기

    public class Program
    {
        private static Character player;
        private static List<WorldItems> worldItems;
        private static List<MyItems> myItems;

        public class Character
        {
            // 캐릭터 클래스, 필드 선언, 자동 프로퍼티
            public string Name { get; }
            public string Job { get; }
            public int Level { get; }
            public int Atk { get; }
            public int Def { get; }
            public int Hp { get; }
            public int Gold { get; }
            public Character // 생성자 정의
            (string name, string job, int level, int atk, int def, int hp, int gold)
            {
                // 생성자를 통해 필드 값 초기화
                Name = name;
                Job = job;
                Level = level;
                Atk = atk;
                Def = def;
                Hp = hp;
                Gold = gold;
            }
        }
        public class WorldItems
        {
            // 아이템 클래스 만들기
            public string Name { get; }
            public string Type { get; }
            public string Info { get; }
            public int Price { get; }
            public int Atk { get; }
            public int Def { get; }

            public WorldItems
            (string name, string type, string info, int price, int atk, int def)
            {
                Name = name;
                Type = type;
                Info = info;
                Price = price;
                Atk = atk;
                Def = def;
            }
            public static void ItemDataSetting()
            {
                worldItems = new List<WorldItems>();
                worldItems.Add(new WorldItems("나무 검", "무기", " 검의 형상으로 깎은 나무... ", 500, 3, 0));
                worldItems.Add(new WorldItems("돌 검", "무기", " 단순하지만 위력적 ", 1000, 5, 0));
                worldItems.Add(new WorldItems("철 검", "무기", " 충분한 공격력을 갖춘 보편적인 장비 ", 1500, 10, 0));
                worldItems.Add(new WorldItems("천 갑옷", "방어구", " 급소부위만 두텁게 한 수준으로 효과는 미미 ", 500, 0, 3));
                worldItems.Add(new WorldItems("가죽 갑옷", "방어구", " 가볍지만 유연한 방어를 제공 ", 1000, 0, 5));
                worldItems.Add(new WorldItems("사슬 갑옷", "방어구", " 기동성과 효과를 적절히 갖춘 보편적인 장비 ", 1500, 0, 10));
               
            }
        }
        public class MyItems : WorldItems
        {
            // 월드아이템 정보를 가져오기
            // 보유하거나 장착하고 있으면 MyItems

            public bool Equipped { get; set; }

            public MyItems(WorldItems item) : base(item.Name, item.Type, item.Info, item.Price, item.Atk, item.Def)
            {
                Equipped = false;
            }

        }

        static void PlayerSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("Leonidas", "전사", 1, 10, 5, 100, 1500);
            // 아이템 정보 세팅
            myItems = new List<MyItems>();
            myItems.Add(new MyItems(worldItems[0]));
            myItems.Add(new MyItems(worldItems[3]));

        }

        static void DisplayGameStart()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ! ~ Dungeon Of Sparta ~ ! ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(" 스파르타 마을에 오신 여러분 환영합니다! ");
            Console.WriteLine(" 마을에서 할 수 있는 활동입니다. ");
            Console.WriteLine();
            Console.WriteLine(" 1. 상태 보기 ");
            Console.WriteLine(" 2. 가방 보기 ");
            Console.WriteLine();
            Console.WriteLine(" 원하시는 행동을 입력해주세요! ");

            // 입력 받아오기
            int input = CheckUserInput(1, 2);
            switch (input)
            {
                case 1:
                    // 상태창 보기
                    DisplayMyInfo();
                    break;
                case 2:
                    // 인벤토리 보기
                    DisplayInventory();
                    break;
            }
        }

        static void DisplayMyInfo()
        {
            MyItems item;
            string itemBonus;

            // 캐릭터 클래스의 정보를 가져오기
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ~ 상태 ~ ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(" 캐릭터의 정보를 표시합니다. ");
            Console.WriteLine();
            Console.WriteLine($" 이름 : {player.Name} ");
            Console.WriteLine($" 직업 : {player.Job} ");
            Console.WriteLine($" 레벨 : {player.Level} ");            
            Console.WriteLine($" 공격력 : {player.Atk} ");            
            Console.WriteLine($" 방어력 : {player.Def} ");
            Console.WriteLine($" 돈 : {player.Gold}G ");
            Console.WriteLine();
            Console.WriteLine(" 0. 나가기 ");
            
            int input = CheckUserInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameStart();
                    break;
            }

        }
        static void DisplayInventory()
        {
            // 인벤토리 창 만들기
            // 보유한 아이템만 보여주기 Myitems
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ~ 가방 ~ ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(" 보유 중인 아이템을 관리할 수 있습니다. ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" [아이템 목록] ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(" ~ 무기 ~ ");
            Console.WriteLine();
            ItemsByType(myItems, "무기");
            Console.WriteLine();
            Console.WriteLine(" ~ 방어구 ~ ");
            Console.WriteLine();
            ItemsByType(myItems, "방어구");
            Console.WriteLine();
            Console.WriteLine(" 1. 장착 관리 ");
            Console.WriteLine(" 0. 나가기 ");
            Console.WriteLine();
            Console.WriteLine(" 원하시는 행동을 입력해주세요! ");

            int input = CheckUserInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGameStart();
                    break;
                case 1:
                    DisplayEquipment();
                    break;
            }
        }
        static void DisplayEquipment()
        {
            // 장착 관리 창
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ~ 장착 관리 ~ ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(" 장착을 원하는 장비의 번호를 입력하세요 ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" [아이템 목록] ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(" ~ 무기 ~ ");
            Console.WriteLine();
            ItemsByType(myItems, "무기");
            Console.WriteLine();
            Console.WriteLine(" ~ 방어구 ~ ");
            Console.WriteLine();
            ItemsByType(myItems, "방어구");
            Console.WriteLine();
            // 번호 선택 
            Console.WriteLine(" 0. 나가기 ");
            Console.WriteLine();

            // 장착 하는거 구현
            int input = CheckUserInput(0, myItems.Count);
            if (input == 0)
            {
                DisplayInventory();
            }
            else 
            {

            }
        }        
        static void ItemsByType(List<MyItems> itemlist, string itemType)
        {
            foreach(MyItems item in itemlist)
            {                
                if (item.Type == itemType)
                {
                    if (itemType == "무기")                    
                    Console.WriteLine($" {item.Name} / {item.Type} / 공격력 : {item.Atk}/ {item.Info} / {item.Price}G ");
                    else if (itemType == "방어구")
                    Console.WriteLine($" {item.Name} / {item.Type} / 방어력 : {item.Def}/ {item.Info} / {item.Price}G ");
                }
            }            
        }
        

        // 입력을 받아서 정수(int) 범위 체크하기
        // 올바른 범위 내의 값이 입력되어야 실행
        static int CheckUserInput(int min,int max)
        {
            while (true) // 무한루프
            {
                // 입력을 받아서 저장하고 정수로 변환
                // 변환에 성공 시 값을 저장하고 true
                // 변환에 실패 시 값을 저장하지 않고 false

                string input = Console.ReadLine();
                bool parseSuccess = int.TryParse(input, out int ret);
                if (parseSuccess) // parseSuccess 가 true 일 때 실행
                {
                    if (ret >= min && ret <= max)
                    {
                        return ret; // input = ret
                    }
                }
                // parseSuccess 가 false 일 때가 아니라 
                // if 에 들어가지 않았을 때
                Console.WriteLine(" 잘못된 입력입니다. ");
            }
        }

        static void Main()
        {
            WorldItems.ItemDataSetting();
            PlayerSetting();           
            DisplayGameStart();
        }        
    }
}