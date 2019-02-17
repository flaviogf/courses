package br.com.livroandroid.carros

import android.app.Application
import android.util.Log

class CarrosApplication : Application() {

    private val tag: String = "CarrosApplication"

    override fun onCreate() {
        super.onCreate()
        instace = this
    }

    override fun onTerminate() {
        super.onTerminate()
        Log.d(tag, "$tag.onTerminate()")
    }

    companion object {

        @JvmStatic()
        var instace: CarrosApplication? = null
            private set
    }
}