
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

    internal class Program
    {
        private static Character player;
        private static List<Items> myitems;
        private static List<Items> shopitems;

        public class Character
        {
            // 캐릭터 클래스, 필드 선언, 자동 프로퍼티

            public string Name { get; }
            public string Job { get; }
            public int Level { get; }
            public int Atk { get; }
            public int Def { get; }
            public int Hp { get; }
            public int Gold { get; set; }
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
        public class Items
        {
            // 아이템 클래스 만들기
            public bool IsEquipped { get; set; }
            public bool IsHave { get; set; }
            public string Name { get; }
            public string Type { get; }
            public string Info { get; }
            public int Price { get; }
            public int Atk { get; }
            public int Def { get; }

            public Items
            (string name, string type, string info, int price, int atk, int def)
            {
                Name = name;
                Type = type;
                Info = info;
                Price = price;
                Atk = atk;
                Def = def;
            }
        }

        static void GameSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("Leonidas", "전사", 1, 10, 5, 100, 2500);
            // 아이템 정보 세팅
            myitems = new List<Items>();
            myitems.Add(new Items("나무 검", "무기", " 검의 형상으로 깎은 나무... ", 500, 3, 0) { IsHave = true });
            myitems.Add(new Items("천 갑옷", "방어구", " 천으로 만든 기본적인 갑옷 ", 500, 0, 3) { IsHave = true });


            shopitems = new List<Items>();
            shopitems.Add(new Items("돌 검", "무기", " 단순하지만 위력적 ", 1000, 5, 0) { IsHave = false });
            shopitems.Add(new Items("철 검", "무기", " 충분한 공격력을 갖춘 보편적인 장비 ", 1500, 10, 0) { IsHave = false });
            shopitems.Add(new Items("가죽 갑옷", "방어구", " 가볍지만 유연한 방어를 제공 ", 1000, 0, 5) { IsHave = false });
            shopitems.Add(new Items("사슬 갑옷", "방어구", " 기동성과 효과를 적절히 갖춘 보편적인 장비 ", 1500, 0, 10) { IsHave = false }); 
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
            Console.WriteLine(" 3. 상점 보기 ");
            Console.WriteLine();
            Console.WriteLine(" 원하시는 행동을 입력해주세요! ");

            // 입력 받아오기
            int input = CheckUserInput(1, 3);
            switch (input)
            {
                case 1:
                    // 상태 보기
                    DisplayMyInfo();
                    break;
                case 2:
                    // 가방 보기
                    DisplayInventory();
                    break;
                case 3:
                    // 상점 보기
                    DisplayShop();
                    break;
            }
        }

        static void DisplayMyInfo()
        {
            string playerAtk = player.Atk.ToString();
            string playerDef = player.Def.ToString();
            int bonusAtk = 0;
            int bonusDef = 0;
            // 장착된 장비 정보 상태창 표시
            for (int i = 0; i < myitems.Count; i++)
            {
                if (myitems[i].IsEquipped)
                {
                    bonusAtk += myitems[i].Atk;
                    bonusDef += myitems[i].Def;
                }
            }
            if (bonusAtk != 0)
            {                
                playerAtk += ($" (+{bonusAtk})");
            }            
            if (bonusDef != 0)
            {
                playerDef += ($" (+{bonusDef})");
            }
            
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
            Console.Write($" 공격력 : {playerAtk} ");
            Console.WriteLine();
            Console.Write($" 방어력 : {playerDef} ");
            Console.WriteLine();
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
            // 반복문으로 내 아이템 모두 출력
            for (int i = 0; i < myitems.Count; i++)
            {
                Console.Write(" - ");
                ItemText(myitems[i], false);
            }
            Console.WriteLine();
            Console.WriteLine(" 1. 장착 관리 ");
            Console.WriteLine();
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
            // 아이템 목록 나오게하기
            // 1. 장착관리 창에서는 번호가 붙음
            // 2. 번호를 입력 , 장착 중이지 않다면 장착하고 [E], 장착 중이라면 해제하고 [E] 삭제
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
            // 반복문으로 내 아이템 모두 출력
            for (int i = 0; i < myitems.Count; i++)
            {
                Console.Write($" {i + 1}.");
                ItemText(myitems[i], false);
            }
            Console.WriteLine();
            // 선택지 아이템 숫자만큼 출력
            for (int i = 1; i <= myitems.Count; i++)
            {
                Console.WriteLine($" {i}. 장착/해제하기 ");
            }
            Console.WriteLine();
            Console.WriteLine(" 0. 나가기 ");
            Console.WriteLine();

            // 번호를 선택해서 장착하기
            int input = CheckUserInput(0, myitems.Count);
            if (input > 0 && input <= myitems.Count)
            {
                int itemIndex = input - 1;
                Items selectedItems = myitems[itemIndex];

                selectedItems.IsEquipped = !selectedItems.IsEquipped;
                DisplayEquipment();
            }
            else if (input == 0)
            {
                DisplayInventory();
            }
        }
        static void DisplayShop()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ~ 상점 ~ ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(" 아이템을 구매/판매할 수 있습니다. ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($" [보유 골드] \t{player.Gold} G ");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" [아이템 목록] ");
            Console.ResetColor();
            Console.WriteLine();
            for (int i = 0; i < shopitems.Count; i++)
            {
                Console.Write(" - ");
                ItemText(shopitems[i],true);
            }
            Console.WriteLine();
            Console.WriteLine(" 1. 구매하기 ");
            Console.WriteLine(" 2. 판매하기 ");
            Console.WriteLine();
            Console.WriteLine(" 0. 나가기 ");
            Console.WriteLine();
            Console.WriteLine(" 원하시는 행동을 입력해주세요! ");

            int input = CheckUserInput(0, 2);
            switch (input)
            {
                case 0:
                    DisplayGameStart();
                    break;
                case 1:
                    // 구매하기
                    DisplayBuy();
                    break;
                case 2:
                    // 판매하기
                    // DisplaySell();
                    break;

            }
        }

        static void DisplayBuy(string msg = "")
        {            
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ~ 상점 ~ ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(" 아이템을 구매할 수 있습니다. ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($" [보유 골드] \t{player.Gold} G ");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" [아이템 목록] ");
            Console.ResetColor();
            Console.WriteLine();
            for (int i = 0; i < shopitems.Count; i++)
            {               
                    Console.Write($" {i + 1}.");
                    ItemText(shopitems[i],true);                
            }
            Console.WriteLine(); 
            for (int i = 1; i <= shopitems.Count; i++)
            {
                Console.WriteLine($" {i}. 구매하기 ");
            }
            Console.WriteLine();
            Console.WriteLine(" 0. 나가기 ");
            Console.WriteLine();
            Console.WriteLine(" 원하시는 행동을 입력해주세요! ");
            if (!string.IsNullOrEmpty(msg))            
                Console.WriteLine(msg); 
            
            int input = CheckUserInput(0, shopitems.Count);
                
            if (input > 0 && input <= shopitems.Count)   
            {   
                int itemIndex = input - 1;
                Items choiceItems = shopitems[itemIndex];               
               
                if (shopitems[itemIndex].Price <= player.Gold)
                {                    
                    if(shopitems[itemIndex].IsHave == false)
                    {
                        choiceItems.IsHave = true;
                        player.Gold -= shopitems[itemIndex].Price;
                        myitems.Add(choiceItems);
                        DisplayBuy($" {shopitems[itemIndex].Name} 을 구매하셨습니다. ");                        
                    }
                    else if (shopitems[itemIndex].IsHave == true)
                    {
                        DisplayBuy(" 보유중인 아이템입니다. ");
                    }
                    // DisplayBuy();
                }
                else if (shopitems[itemIndex].Price > player.Gold)
                {
                    DisplayBuy(" Gold 가 부족합니다. ");
                }
            }
            else if (input == 0)
            {
                DisplayShop();
            }
        }

        static void ItemText(Items item, bool isShop) // 아이템 정보 출력 함수
        {
            string isHave = item.IsHave ? "보유중" : $"{item.Price.ToString()}G";
            string typeText = (item.Type == "무기") ? "공격력" : "방어력";
            int statValue = (item.Type == "무기") ? item.Atk : item.Def;
            string equippedMark = "   ";
            if (!isShop)
            {
                equippedMark = item.IsEquipped ? "[E]" : "   ";
            }            
            string iteminfomation = $"{equippedMark}{item.Name} | {typeText} : {statValue} | {item.Info} | {isHave}";
            Console.WriteLine(iteminfomation);
        }      
        static int CheckUserInput(int min,int max)
        {            
            while (true) // 무한루프
            {
                // 입력을 받아서 저장하고 정수로 변환
                // 변환에 성공 시 값을 저장하고 true
                // 변환에 실패 시 값을 저장하지 않고 false

                string input = Console.ReadLine();
                bool parseSuccess = int.TryParse(input, out int ret);
                if (parseSuccess) 
                {
                    // 입력을 받아서 정수(int) 범위 체크하기
                    // 올바른 범위 내의 값이 입력되어야 실행
                    if (ret >= min && ret <= max)
                    {
                        return ret; // input = ret
                    }
                }                
                Console.WriteLine(" 잘못된 입력입니다. ");
            }
        }

        static void Main()
        {
            GameSetting();           
            DisplayGameStart();
        }        
    }
}