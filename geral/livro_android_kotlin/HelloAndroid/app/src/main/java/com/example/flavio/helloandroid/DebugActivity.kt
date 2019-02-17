package com.example.flavio.helloandroid

import android.os.Bundle
import android.support.v7.app.AppCompatActivity
import android.util.Log

abstract class DebugActivity : AppCompatActivity() {

    val className: String
        get() {
            val s = javaClass.name
            return s.substring(s.lastIndexOf("."))
        }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        Log.d(className, "onCreate()")
    }

    override fun onStart() {
        super.onStart()
        Log.d(className, "onStart()")
    }

    override fun onResume() {
        super.onResume()
        Log.d(className, "onResume()")
    }

    override fun onPause() {
        super.onPause()
        Log.d(className, "onPause()")
    }

    override fun onStop() {
        super.onStop()
        Log.d(className, "onStop()")
    }

    override fun onDestroy() {
        super.onDestroy()
        Log.d(className, "onDestroy()")
    }

    override fun onRestart() {
        super.onRestart()
        Log.d(className, "onRestart()")
    }

    override fun onSaveInstanceState(outState: Bundle?) {
        super.onSaveInstanceState(outState)
        Log.d(className, "onSaveInstanceState()")
    }
}