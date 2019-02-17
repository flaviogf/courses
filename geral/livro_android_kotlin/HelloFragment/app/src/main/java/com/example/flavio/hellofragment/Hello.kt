package com.example.flavio.hellofragment

import android.os.Bundle
import android.support.v4.app.Fragment
import android.view.*
import android.widget.Toast

class Hello : Fragment() {

    override fun onCreateView(inflater: LayoutInflater?, container: ViewGroup?,
                              savedInstanceState: Bundle?): View? {
        setHasOptionsMenu(true)
        return inflater?.inflate(R.layout.fragment_hello, container, false)
    }

    override fun onCreateOptionsMenu(menu: Menu?, inflater: MenuInflater?) {
        inflater?.inflate(R.menu.menu_fragment, menu)
        super.onCreateOptionsMenu(menu, inflater)
    }

    override fun onOptionsItemSelected(item: MenuItem?): Boolean {
        when (item?.itemId) {
            R.id.hello -> toast("Hello fragment")
        }
        return super.onOptionsItemSelected(item)
    }

    private fun toast(mensagem: String) {
        Toast.makeText(activity, mensagem, Toast.LENGTH_SHORT).show()
    }
}
