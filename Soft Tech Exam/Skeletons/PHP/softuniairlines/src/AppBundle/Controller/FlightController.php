<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Flight;
use AppBundle\Form\FlightType;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\Routing\Annotation\Route;

class FlightController extends Controller
{
    /**
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index()
    {
        $flights = $this->getDoctrine()->getRepository(Flight::class)->findAll();
        return $this->render("flight/index.html.twig",
            ['flights' => $flights]);
    }

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\RedirectResponse|\Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        $flight = new Flight();
        $form = $this->createForm(FlightType::class, $flight);
        $form->handleRequest($request);
        if ($form->isSubmitted()) {
            $em = $this->getDoctrine()->getManager();
            $em->persist($flight);
            $em->flush();
            return $this->redirect("/");
        }
        {
            return $this->render("flight/create.html.twig",
                ['form' => $form->createView()]);
        }
    }

    /**
     * @Route("/edit/{id}", name="edit")
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\RedirectResponse|\Symfony\Component\HttpFoundation\Response
     */
    public function edit($id, Request $request)
    {
        $flight = $this->getDoctrine()->getRepository(Flight::class)->find($id);
        $form = $this->createForm(FlightType::class, $flight);
        $form->handleRequest($request);
        if ($form->isSubmitted()) {
            $em = $this->getDoctrine()->getManager();
            $em->merge($flight);
            $em->flush();
            return $this->redirect("/");
        }
        return $this->render("flight/edit.html.twig",
            ['form' => $form->createView(), "flight" => $flight]);
    }

    /**
     * @Route("/delete/{id}", name="delete")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function delete($id, Request $request)
    {
        $flight = $this->getDoctrine()->getRepository(Flight::class)->find($id);
        $form = $this->createForm(FlightType::class, $flight);
        $form->handleRequest($request);
        if ($form->isSubmitted()) {
            $em = $this->getDoctrine()->getManager();
            $em->remove($flight);
            $em->flush();
            return $this->redirect("/");
        }
        return $this->render("flight/delete.html.twig",
            ['form' => $form->createView(), "flight" => $flight]);
    }
}
