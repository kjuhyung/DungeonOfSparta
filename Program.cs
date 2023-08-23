
namespace DungeonOfSparta
{ 
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
            // 게임 시작 화면
            // 게임 시작시 간단한 소개, 마을에서 할 수 있는 행동
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

            // 상태 보기
            // 캐릭터의 정보를 표시
            // 7개의 속성 레벨,이름,직업,공격력,방어력,체력,돈
            string playerAtk = player.Atk.ToString();
            string playerDef = player.Def.ToString();
            int bonusAtk = 0;
            int bonusDef = 0;
            // 장착된 장비의 추가 공격력,방어력 표시
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
            // 인벤토리
            // 보유 중인 아이템을 전부 보여준다.
            // 장착중인 아이템 앞에는 [E] 표시가 붙는다
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
            // 선택지를 아이템 숫자만큼 출력
            for (int i = 1; i <= myitems.Count; i++)
            {
                Console.WriteLine($" {i}. 장착/해제하기 ");
            }
            Console.WriteLine();
            Console.WriteLine(" 0. 나가기 ");
            Console.WriteLine();

            // 번호를 입력해서 장착/해제하기
            int input = CheckUserInput(0, myitems.Count);
            if (input > 0 && input <= myitems.Count)
            {
                int itemIndex = input - 1;
                Items choicedItem = myitems[itemIndex];

                choicedItem.IsEquipped = !choicedItem.IsEquipped;
                DisplayEquipment();
            }
            else if (input == 0)
            {
                DisplayInventory();
            }
        }
        static void DisplayShop()
        {
            // 상점 아이템 목록을 표시
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
                ItemText(shopitems[i], false);
            }
            Console.WriteLine();
            Console.WriteLine(" 1. 구매하기 ");
            Console.WriteLine(" 2. 판매하기 ");
            Console.WriteLine();
            Console.WriteLine(" 0. 나가기 ");
            Console.WriteLine();
            Console.WriteLine(" 원하시는 행동을 입력해주세요! ");

            // 번호를 입력해서 구매/판매 이동하기
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
                    DisplaySell();
                    break;

            }
        }

        static void DisplayBuy(string msg = "")
        {   
            // 구매하기
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
            // 상점의 아이템 목록과 선택지 표시
            for (int i = 0; i < shopitems.Count; i++)
            {               
                    Console.Write($" {i + 1}.");
                    ItemText(shopitems[i], false);                
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
            
            // 번호를 입력해서 구매 시도
            // 골드 상황에 따라 다른 출력
            // 구매 성공시 골드변경,아이템리스트 추가
            int input = CheckUserInput(0, shopitems.Count);
                
            if (input > 0 && input <= shopitems.Count)   
            {   
                int itemIndex = input - 1;
                Items choicedItem = shopitems[itemIndex];               
               
                if (choicedItem.Price <= player.Gold)
                {                    
                    if(choicedItem.IsHave == false)
                    {
                        choicedItem.IsHave = true;
                        player.Gold -= choicedItem.Price;
                        myitems.Add(choicedItem);
                        DisplayBuy($" {choicedItem.Name} 을 구매하셨습니다. ");                        
                    }
                    else if (choicedItem.IsHave == true)
                    {
                        DisplayBuy(" 보유중인 아이템입니다. ");
                    }
                    // DisplayBuy();
                }
                else if (choicedItem.Price > player.Gold)
                {
                    DisplayBuy(" Gold 가 부족합니다. ");
                }
            }
            else if (input == 0)
            {
                DisplayShop();
            }
        }
        static void DisplaySell(string msg = "")
        {
            // 판매하기
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ~ 상점 ~ ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(" 아이템을 판매할 수 있습니다. ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($" [보유 골드] \t{player.Gold} G ");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" [아이템 목록] ");
            Console.ResetColor();
            Console.WriteLine();
            // 내 아이템 목록과 선택지 표시
            for (int i = 0; i < myitems.Count; i++)
            {
                Console.Write($" {i + 1}.");
                ItemText(myitems[i], true);
            }
            Console.WriteLine();
            for (int i = 1; i <= myitems.Count; i++)
            {
                Console.WriteLine($" {i}. 판매하기 ");
            }
            Console.WriteLine();
            Console.WriteLine(" 0. 나가기 ");
            Console.WriteLine();
            Console.WriteLine(" 원하시는 행동을 입력해주세요! ");           
            Console.WriteLine(msg);

            // 번호를 입력해서 판매
            // 판매가격은 아이템가격의 85%
            // 판매 시 텍스트 출력
            // 리스트 삭제 및 골드 추가
            int input = CheckUserInput(0, myitems.Count);
           
            if (input > 0 && input <= myitems.Count)
            {
                int itemIndex = input - 1;
                Items choicedItems = myitems[itemIndex];  
                if (choicedItems.IsEquipped)
                {
                    choicedItems.IsEquipped = false;
                }
                choicedItems.IsHave = false;
                player.Gold += (int)(choicedItems.Price*0.85);
                myitems.Remove(choicedItems);
                
              DisplaySell
              ($" {choicedItems.Name} 을 판매하셨습니다. \n {choicedItems.Price *0.85} G 를 얻었습니다.");
            }
            else if (input == 0)
            {
                DisplayShop();
            }
        }

        static void ItemText(Items item, bool isSell) 
        {
            // 아이템 정보를 출력하는 함수
            // 판매창에서만 가격이 변동
            // 장착 여부 표시
            // 아이템 타입에 따라 공격력 또는 방어력 표시
            string isHave = item.IsHave ? "보유중" : $"{item.Price} G";
            string typeText = item.Type == "무기" ? "공격력" : "방어력";
            int statValue = item.Type == "무기" ? item.Atk : item.Def;
            string equippedMark = item.IsEquipped ? "[E]" : "   ";
            if (isSell)
            {
                double SellPrice = item.Price * 0.85;
                string sellitemInfo = $"{equippedMark}{item.Name} | {typeText} : {statValue} | {item.Info} | {SellPrice} G";
                Console.WriteLine(sellitemInfo);
            }
            else
            {
                string itemInfomation = $"{equippedMark}{item.Name} | {typeText} : {statValue} | {item.Info} | {isHave}";
                Console.WriteLine(itemInfomation);
            }
            
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