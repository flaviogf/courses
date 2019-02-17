package com.example.flavio.hellofragment

import android.os.Bundle
import android.support.v7.app.AppCompatActivity

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        if (savedInstanceState == null) {
            val fragmentTransaction = supportFragmentManager.beginTransaction()
            val fragment = Hello()
            /*
                parametros container, fragment e tag
            */
            fragmentTransaction.add(R.id.frame, fragment, "HelloFragment")
            fragmentTransaction.commit()
        }
    }
}
