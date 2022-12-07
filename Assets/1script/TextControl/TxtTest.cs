using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TxtTest : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset 测试文本; //保存所有文本内容的文件
    public GameObject txtshow; //文本展示框
    public int bookid = 0; //书本id
    public int page = 0; //页数
    public string[] str_book; //储存被导出的文本
    public string testword; 



    private void Start()
    {
        str_book = 测试文本.text.Split('\n'); //0号为页数标记 1为封面 2+为书本内容 使文本按回车分割
        Text txtword_start;
        txtword_start = txtshow.transform.GetComponent<Text>();
        int mainid = GameObject.Find("按钮控制组").GetComponent<Mainbutton>().booknum; //读取当前书本id
        string[] str_main = str_book[mainid].Split('|'); //使文本按|分割
        txtword_start.text = str_main[1]; //首先输出封面文本
        page = 1; 
    }

    public void uptxt(int bookid_out)
    {
        bookid = bookid_out;       //记录输入的书本ID
        Text txtword_up;
        txtword_up = txtshow.transform.GetComponent<Text>();//接管txt内容
        string[] str_page = str_book[bookid].Split('|');//分隔文本
        int pagenum;
        int.TryParse(str_page[0],out pagenum);//提取0号页数信息
        if(page < pagenum + 1)//显示内容
        {
            page++;//增加页数标记器
            txtword_up.text = " ";//清空文本
            txtword_up.DOText(str_page[page],0.5f);//重新读入文本
        }
        
 
        
    }

    public void downtxt(int bookid_out)
    {
        bookid = bookid_out;       //记录输入的书本ID
        Text txtword_down;
        txtword_down = txtshow.transform.GetComponent<Text>();//接管txt内容
        string[] str_page = str_book[bookid].Split('|');//分隔文本
        /*int pagenum;
        int.TryParse(str_page[0], out pagenum);//提取0号页数信息(反转了 这边好像不需要提取)*/
        if (page > 2)//显示内容
        {
            page--;//减少页数标记器
            txtword_down.text = " ";//清空文本
            txtword_down.DOText(str_page[page],0.5f);//重新读入文本
        }
    }
}
