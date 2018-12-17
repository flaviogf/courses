package br.com.livroandroid.carros.domain

import android.os.Parcelable
import kotlinx.android.parcel.Parcelize

@Parcelize
data class Carro(
        val id: Long,
        val nome: String,
        val tipo: String = "",
        val desc: String = "",
        val urlFoto: String = "",
        val urlInfo: String = "",
        val urlVideo: String = "",
        val latitude: String = "",
        val longitude: String = ""
) : Parcelable
