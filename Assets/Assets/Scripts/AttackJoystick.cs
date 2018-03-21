using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AttackJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image joystickImg;
	private Image bgImg;
	private Vector3 inputVector;


	void Start () 
	{
		bgImg = GetComponent<Image>(); // bgImg = 이 스프라이트(JoystickBackground)의 이미지
		joystickImg = transform.GetChild(0).GetComponent<Image>(); // joystickImg = 이 스프라이트(JoystickBackground)의 첫번째 자식(즉, Joystick) 이미지
	}

	public virtual void OnDrag(PointerEventData ped) // 패드를 드래그 할 때 [사용자 지정 함수]
	{
		Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) // bgImg영역에 터치가 발생했을 때
		{
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x); //pos.x = 터치한곳의 x좌표를 중앙을 기준으로 -0.5 ~ 0.5의 범위로 나타냄
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y); //pos.y = 터치한곳의 y좌표를 중앙을 기준으로 -0.5 ~ 0.5의 범위로 나타냄

			inputVector = new Vector3(pos.x * 2, pos.y * 2, 0); // -0.5 ~ 0.5의 범위를 -1 ~ 1의 범위로 바꿔줌
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector; // [(x * x + y * y) 루트2] 값 즉, x와 y의 대각선 길이가 1을 넘어가면 노멀라이즈를 적용시켜줌

			joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 2.5f), inputVector.y * (bgImg.rectTransform.sizeDelta.y / 2.5f)); // Joystick이미지 이동
		}
	}

	public virtual void OnPointerDown(PointerEventData ped) // 패드가 눌렸을때 [라이브러리 함수]
	{
		OnDrag(ped); // 드래그 실행
	}

	public virtual void OnPointerUp(PointerEventData ped) // 패드가 눌리지 않았을때 [라이브러리 함수]
	{
		inputVector = Vector3.zero; // Vector3.zero == new Vector3(0, 0, 0);
		joystickImg.rectTransform.anchoredPosition = Vector3.zero; // Joystick가운데로 이동
		inputVector.x = -inputVector.x;
		inputVector.y = -inputVector.y;
	}
		
	public float GetHorizontalValue() //투사체 이동시킬때 x값을 받기 위해 사용될 함수  [사용자 지정 함수]
	{
		return inputVector.x;
	}

	public float GetVerticalValue() // 투사체 이동시킬때 y값을 받기 위해 사용될 함수 [사용자 지정 함수]
	{
		return inputVector.y;
	}
}
