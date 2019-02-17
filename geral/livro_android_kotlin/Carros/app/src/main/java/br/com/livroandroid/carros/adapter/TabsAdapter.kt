package br.com.livroandroid.carros.adapter

import android.content.Context
import android.os.Bundle
import android.support.v4.app.Fragment
import android.support.v4.app.FragmentManager
import android.support.v4.app.FragmentPagerAdapter
import br.com.livroandroid.carros.domain.TipoCarro
import br.com.livroandroid.carros.fragments.CarrosFragment

class TabsAdapter(private val context: Context, fm: FragmentManager) : FragmentPagerAdapter(fm) {

    override fun getItem(position: Int): Fragment {
        val tipo = getTipo(position)
        val fragment = CarrosFragment()
        fragment.arguments = Bundle()
        fragment.arguments.putSerializable("tipo", tipo)
        return fragment
    }

    override fun getPageTitle(position: Int): CharSequence {
        val tipo = getTipo(position)
        return context.getString(tipo.string)
    }

    override fun getCount() = 3

    private fun getTipo(position: Int) = when (position) {
        0 -> TipoCarro.Classicos
        1 -> TipoCarro.Esportivos
        else -> TipoCarro.Luxo
    }
}