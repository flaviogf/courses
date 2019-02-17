package br.com.flaviogf.converter;

import javax.faces.component.UIComponent;
import javax.faces.context.FacesContext;
import javax.faces.convert.Converter;
import javax.faces.convert.FacesConverter;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;

@FacesConverter("br.com.flaviogf.converter.CalendarConverter")
public class CalendarConvertor implements Converter {

    @Override
    public Object getAsObject(FacesContext facesContext, UIComponent uiComponent, String s) {
        Calendar calendar = Calendar.getInstance();
        try {
            SimpleDateFormat format = new SimpleDateFormat("dd/MM/yy");
            calendar.setTime(format.parse(s));
        } catch (ParseException e) {
            e.printStackTrace();
        }
        return calendar;
    }

    @Override
    public String getAsString(FacesContext facesContext, UIComponent uiComponent, Object o) {
        Calendar data = (Calendar) o;
        SimpleDateFormat format = new SimpleDateFormat();
        return format.format(data.getTime());
    }
}
