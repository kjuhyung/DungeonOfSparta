
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
       
        
        static void Main()
        {
            
        }

        
    }
    
}