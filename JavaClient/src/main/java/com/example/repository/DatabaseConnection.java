package com.example.repository;


import com.example.domain.Match;
import com.example.domain.RepositoryException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;

/**
 * Created by Sergiu on 5/8/2017.
 */
public class DatabaseConnection {
    private static SessionFactory sessionFactory = null;

    public static Session newSession() throws RepositoryException {
        if (null == sessionFactory){
            sessionFactory = new Configuration()
                    .configure("hibernate.cfg.xml")
                    .addAnnotatedClass(Match.class)
                    .buildSessionFactory();
        }
        return sessionFactory.openSession();
    }


    public static void closeConnection(){
        if(sessionFactory == null)
            return;
        sessionFactory.close();
    }
}