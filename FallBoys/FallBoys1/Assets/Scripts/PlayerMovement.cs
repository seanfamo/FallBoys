using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed; //
    [SerializeField] private float rotationSpeed = 500;

    public Animator animator;

    private Touch _touch; //Asýl nokta sadece ileri hareket ederek karakterin nereye döneceðini belirlemek. 

    private Vector3 _touchDown; //ekrana dokunduðumda bir nokta alacaðým
    private Vector3 _touchUp; //býraktýðýmda farklý bir nokta alacaðým. Ardýndan çýkarma iþlemi yapacaðým böylece gideceðim yönün vektörünü elde edeceðim.

    private bool _dragStarted; //sürükleme baþlangýcýný kontrol edeceðim deðiþken
    private bool isMoving;
    private void Start()
    {
        animator.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.touchCount > 0) //ekrana bir input varsa 
        {
            _touch = Input.GetTouch(0); //ilk aldýðým inputu kendi inputuna eþitliyorum
            if (_touch.phase==TouchPhase.Began) //dokunma iþlemi baþladýðý zaman
            {
                _dragStarted = true; //dokunma baþladý bilgisini deðiþkenime gönderiyorum.
                animator.SetBool("isMoving", true);//animator'den bu deðiþkeni kullanacaðým için true'ya çekiyorum
                _touchDown = _touch.position; 
                _touchUp = _touch.position; // 2 pozisyonu da elde ettim
            }
        }
        if (_dragStarted) //kullanýcýnýn elini çekme olasýlýðý olduðu için touch phase moved kontrolleriyle hareket ettireceðim.
        {
            if (_touch.phase == TouchPhase.Moved)
            {
                _touchDown = _touch.position; //baþlangýç pozisyonumu aldým.
            }
            if (_touch.phase== TouchPhase.Ended)  
            {
                _touchDown = _touch.position;  //bitiþ pozisyonumu aldým.
                animator.SetBool("isMoving", false);
                _dragStarted = false; //iþlemlerin bittiðini deðiþkenlerime haber verdim.
            }
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculatingRotation(),rotationSpeed*Time.deltaTime);
            //karakterimizi hareket ettirmemizi saðlýyor nereden baþlayacaðýz nerde býrakacaðýz nereye bakacaðýz
            gameObject.transform.Translate(movementSpeed * Time.deltaTime * Vector3.forward); // ileri hareket etmesi için
        }
    }
    Quaternion CalculatingRotation() // quaternion ile yönü manipule ederek açýyý alacaðým rotasyonda
    {
        Quaternion temp = Quaternion.LookRotation(CalculatingDirection(),Vector3.up); //bir vektör verildiðinde o yöne bakýlmasýný saðlýyor
        return temp;
    }

    Vector3 CalculatingDirection() //fark alýp fonksiyonu çaðýrdýðým zaman vektör3 deðer döndürmesi için
    {
        Vector3 temp = (_touchDown - _touchUp).normalized; //vektörleri küçültmek için normalized kullanýyorum
        temp.z = temp.y; // y ekseninde bir hareket olmasýn istediðim için z'ye eþitledim
        temp.y = 0;
        return temp;//artýk bu fonksiyon bana kullanýcýnýn oluþturduðu çizginin vektörel halini verebilir.
    }
}
