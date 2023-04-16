using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float baseHealth = 100f;          
    public Slider slider;
    public Image image;    

   
    private Color FULL_HEALTH_COLOR = Color.green;
    private Color ZERO_HEALTH_COLOR = Color.red;
    public float currentHealth;  
    private bool isDead;            


    private void OnEnable()
    {
        currentHealth = baseHealth;
        isDead = false;
        updateHealthUI();
    }

    private void Update()
    {
        updateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
        currentHealth -= damage;
        updateHealthUI();

        if(currentHealth <=0f && !isDead){
            OnDeath();
        }
    }


    private void updateHealthUI()
    {
        slider.value = currentHealth;
        image.color = Color.Lerp(ZERO_HEALTH_COLOR, FULL_HEALTH_COLOR, currentHealth / baseHealth);
    }


    private void OnDeath()
    {
        isDead = true;
        gameObject.SetActive(false);
    }
}