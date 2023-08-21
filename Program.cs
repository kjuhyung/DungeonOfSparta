
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
        public class Character
        {
            // 캐릭터 클래스, 필드 선언, 자동 프로퍼티
            public string Name { get; }
            public string Job { get;}
            public int Level { get; }
            public int Atk { get; }
            public int Def { get; }
            public int Hp { get; }
            public int Gold { get; }
            public Character // 생성자 정의
            (string name, string job,int level,int atk,int def, int hp, int gold)
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
        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("Leonidas","전사",1,10,5,100,1500);
            

            // 아이템 정보 세팅

        }

        static void DisplayGameStart()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" 스파르타 마을에 오신 여러분 환영합니다! ");
            Console.WriteLine(" 마을에서 할 수 있는 활동입니다. ");
            Console.WriteLine();
            Console.WriteLine(" 1. 상태창 보기 ");
            Console.WriteLine(" 2. 인벤토리 보기 ");
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
            Console.Clear();
            // 캐릭터 클래스의 정보를 가져오기
            Console.WriteLine(" ~ 상태창 ~ ");
            Console.WriteLine(" 캐릭터의 정보를 표시합니다. ");
            Console.WriteLine();
            Console.WriteLine($" 이름 : {player.Name} ");
            Console.WriteLine($" 직업 : {player.Job} ");
            Console.WriteLine($" Lv : {player.Level} ");
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
            GameDataSetting();
            DisplayGameStart();
        }

        
    }
    
}