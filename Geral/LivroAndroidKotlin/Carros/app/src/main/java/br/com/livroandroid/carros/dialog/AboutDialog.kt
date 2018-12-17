package br.com.livroandroid.carros.dialog

import android.app.Dialog
import android.os.Bundle
import android.support.v4.app.DialogFragment
import android.support.v4.app.FragmentManager
import android.support.v7.app.AlertDialog
import android.text.SpannableStringBuilder
import android.view.LayoutInflater
import android.widget.TextView
import br.com.livroandroid.carros.R
import br.com.livroandroid.carros.extensions.toSppaned

class AboutDialog : DialogFragment() {

    private val versionName: String by lazy {
        val packageManager = activity.packageManager
        val packageName = activity.packageName
        try {
            val info = packageManager.getPackageInfo(packageName, 0)
            info.versionName
        } catch (e: Exception) {
            "N/A"
        }
    }

    override fun onCreateDialog(savedInstanceState: Bundle?): Dialog {
        val aboutLayout = SpannableStringBuilder()
        val html = getString(R.string.about_dialog_text, versionName)
        aboutLayout.append(html.toSppaned())
        val view = LayoutInflater.from(activity)
                ?.inflate(R.layout.dialog_about, null) as TextView
        view.text = aboutLayout
        return AlertDialog.Builder(activity)
                .setTitle(R.string.about_dialog_title)
                .setView(view)
                .setPositiveButton(R.string.ok, null)
                .create()
    }

    companion object {

        private val tag: String = "ABOUT_DIALOG"

        fun showAbout(fm: FragmentManager) {
            val transaction = fm.beginTransaction()
            val fragment = fm.findFragmentByTag(tag)
            if (fragment != null) {
                transaction.remove(fragment)
            }
            transaction.addToBackStack(null)
            AboutDialog().show(transaction, tag)
        }
    }
}