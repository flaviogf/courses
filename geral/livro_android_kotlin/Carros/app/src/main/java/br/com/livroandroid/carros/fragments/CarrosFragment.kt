package br.com.livroandroid.carros.fragments

import android.os.Bundle
import android.support.v7.widget.DefaultItemAnimator
import android.support.v7.widget.LinearLayoutManager
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import br.com.livroandroid.carros.R
import br.com.livroandroid.carros.activity.CarroActivity
import br.com.livroandroid.carros.adapter.CarroAdapter
import br.com.livroandroid.carros.domain.Carro
import br.com.livroandroid.carros.domain.CarroService
import br.com.livroandroid.carros.domain.TipoCarro
import kotlinx.android.synthetic.main.fragment_carros.*
import org.jetbrains.anko.startActivity

class CarrosFragment : BaseFragment() {

    private var tipo: TipoCarro = TipoCarro.Classicos

    private var carros = listOf<Carro>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        tipo = arguments.getSerializable("tipo") as TipoCarro
    }

    override fun onCreateView(inflater: LayoutInflater?, container: ViewGroup?, savedInstanceState: Bundle?) =
            inflater?.inflate(R.layout.fragment_carros, container, false)

    override fun onViewCreated(view: View?, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        with(fragment_carro_recycler_view) {
            layoutManager = LinearLayoutManager(activity)
            itemAnimator = DefaultItemAnimator()
            setHasFixedSize(true)
        }
    }

    override fun onResume() {
        super.onResume()
        taskCarros()
    }

    private fun taskCarros() {
        carros = CarroService.getCarros(activity, tipo)
        fragment_carro_recycler_view.adapter = CarroAdapter(carros) {
            activity.startActivity<CarroActivity>("carro" to it)
        }
    }
}
