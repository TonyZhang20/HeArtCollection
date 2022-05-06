using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject playerp;
    public GameObject enemyp;
    public GameObject panel;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    public AudioSource playerAttack;
    public AudioSource enemyAttack;
    public AudioSource playerHeal;
    public AudioSource enemyDead;
    public AudioSource backgroundMusic;

    private Animator hurt;
    private Animator playerHurt;

    public Text text;
    [TextArea]
    private string firstPart = "【xx30年7月5日  天气：晴 \n 小赛捡回了一条命，我们两个在医院号啕大哭，比画家姐姐还激动，还把她逗笑了。 \n姐姐带着小赛离开了小镇，临走前给我们留了一本子的画，有水彩，有油画，有黑白，还有很多很多各种各样的，画的真好啊，我们都羡慕死了，真想裱起来！ 我以后也要画出这么厉害的画！】 ";
    private string secondPart = "【xx30年10月12日  天气：晴\n 收到了画家姐姐寄来的信，她回到城市里把抄袭者和当时网暴她的人告上了法庭，在绝对的证据之下，姐姐很轻易的胜诉了，尊严和权利不容侵犯，那些烂苹果都受到了应有的惩罚！\n 姐姐现在在国外一边治病一边进修，还办了个人画展呢，好厉害！信里还有三张终生免费参观的门票，我和哥哥感动哭了。】 ";
    private string ThirdPart = "【xx30年10月13日  天气：多云\n 昨天的信里还有一张画，画的是一位正在给两个孩子讲故事的老奶奶，画里扎着两个小辫子的小姑娘怀里还有一只好可爱的小狗哦～是姐姐画的自己小时候，真可爱！原来姐姐以前也有一个哥哥呀。 \n 不知道为什么，这张画让我感觉到莫名的亲切和熟悉…… \n 哇！还有空运过来的巧克力云顶慕斯和制作方法！我有在学哦，失败的就给哥哥吃吧，嘿嘿;-)】";
    private string ForthPart = "【xx30年11月6日  天气：多云 \n 妈妈养了只超——可爱的小猫咪，快快长大哦！】 \n";

    public GameObject blackPanel;
    public Text finishJournal;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        hurt = GetComponent<Animator>();
        playerHurt = GetComponent<Animator>();
        PlayText();
    }

    IEnumerator SetupBattle()
    {
        playerUnit = playerp.GetComponent<Unit>();
        enemyUnit = enemyp.GetComponent<Unit>();

        dialogueText.text = "画家进入异常状态试着解救他";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "哥哥对画家进行了攻击";
        playerAttack.Play();
        enemyp.GetComponent<Animator>().SetTrigger("hurt");


        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            yield return new WaitForSeconds(1f);
            StartCoroutine(EnemyTurn());
        }
    }

    private void PlayText()
    {

    }

    IEnumerator Showtext()
    {
        text.text = string.Empty;
        yield return text.DOText(firstPart, 14f).WaitForCompletion();
        yield return new WaitForSeconds(3f);
        text.text = string.Empty;
        yield return text.DOText(secondPart, 12f).WaitForCompletion();
        yield return new WaitForSeconds(3f);
        
        text.text = string.Empty;
        yield return text.DOText(ThirdPart, 12f).WaitForCompletion();
        yield return new WaitForSeconds(3f);
        
        text.text = string.Empty;
        yield return text.DOText(ForthPart, 8f).WaitForCompletion();
        yield return new WaitForSeconds(3f);
        
        text.text = string.Empty;
        yield return text.DOText("Thanks For Playing", 2f).WaitForCompletion();
		yield return new WaitForSeconds(3f);
		
        //Application.Quit();
        blackPanel.SetActive(true);
        finishJournal.text = string.Empty;
        yield return finishJournal.DOText("好耶，今天的日记也写完了！", 3f).WaitForCompletion();
        
        yield return new WaitForSeconds(3f);
        blackPanel.SetActive(false);
		SceneManager.LoadScene("PlayerScenes");
    }

    IEnumerator EnemyTurn()
    {

        dialogueText.text = "画家对你进行了攻击！";
        enemyAttack.Play();

        playerp.GetComponent<Animator>().SetTrigger("playerhurt");
        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            //enemyp.GetComponent<Animator>().SetTrigger("hurt");
            //playerp.GetComponent<Animator>().SetBool("playerhurt", false);
        }

    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "你控制住了画家";
            enemyDead.Play();
            backgroundMusic.Stop();
            panel.SetActive(true);
            StartCoroutine(Showtext());
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "画家暴走你失败了";
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "选择一个能力:";
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(12);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "妹妹对你进行了治疗";
        playerHeal.Play();

        state = BattleState.ENEMYTURN;

        yield return new WaitForSeconds(1f);

        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }


}
